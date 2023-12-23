using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeeklyBonus : MonoBehaviour
{
    [SerializeField]
    private GameObject _bonus;

    [SerializeField]
    private GameObject _reward;

    [SerializeField]
    private TextMeshProUGUI[] _ticketsTexts;

    [SerializeField]
    private GameObject[] _recievedRewards;

    [SerializeField]
    private WeeklyBonusInfo _weeklyBonusInfo;

    [SerializeField]
    private Slider _rewardSlider;

    [SerializeField]
    private TextMeshProUGUI _sliderText;

    private int[] _tickets = { 5, 5, 10, 10, 15, 15, 50 };

    private void OnEnable()
    {
        if (_weeklyBonusInfo.IsRewardAvailable)
        {
            _weeklyBonusInfo.ReceivedRewardTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day);
            _weeklyBonusInfo.RewardCounter++;
            GameCharacteristics.Instance.Tickets += _tickets[_weeklyBonusInfo.RewardCounter - 1];
        }

        if (_weeklyBonusInfo.RewardCounter < 7)
        {
            for (int i = 0; i < _weeklyBonusInfo.RewardCounter; i++)
            {
                _recievedRewards[i].SetActive(true);
            }
            for (int i = _weeklyBonusInfo.RewardCounter; i < 6; i++)
            {
                _recievedRewards[i].SetActive(false);
            }
            _rewardSlider.value = _weeklyBonusInfo.RewardCounter;
            _sliderText.text = $"{_weeklyBonusInfo.RewardCounter}/7";
        }
        ChooseBonusPanel();
    }

    private void Start()
    {
        for (int i = 0; i < _tickets.Length; i++)
        {
            _ticketsTexts[i].text = $"x{_tickets[i]}";
        }
    }

    private void ChooseBonusPanel()
    {
        if (_weeklyBonusInfo.RewardCounter == 7)
        {
            _bonus.SetActive(false);
            _reward.SetActive(true);
            _weeklyBonusInfo.RewardCounter = 0;
        }
        else
        {
            _bonus.SetActive(true);
            _reward.SetActive(false);
        }
    }
}