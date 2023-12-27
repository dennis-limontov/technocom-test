using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ticketsText;

    [SerializeField]
    private GameObject _rewardReminder;

    [SerializeField]
    private WeeklyBonusInfo _weeklyBonusInfo;

    private const float UPDATE_TIME = 10f;

    private void OnDestroy()
    {
        GameCharacteristics.OnTicketsChanged -= TicketsChangedHandler;
    }

    private void Start()
    {
        GameCharacteristics.OnTicketsChanged += TicketsChangedHandler;

        if (PlayerPrefs.HasKey(nameof(GameCharacteristics.Tickets)))
        {
            GameCharacteristics.Instance.Tickets = PlayerPrefs.GetInt(nameof(GameCharacteristics.Tickets));
        }
        if (PlayerPrefs.HasKey(nameof(GameCharacteristics.CurrentLevel)))
        {
            GameCharacteristics.Instance.CurrentLevel = PlayerPrefs.GetInt(nameof(GameCharacteristics.CurrentLevel));
        }
        if (PlayerPrefs.HasKey(nameof(_weeklyBonusInfo.RewardCounter)))
        {
            _weeklyBonusInfo.RewardCounter = PlayerPrefs.GetInt(nameof(_weeklyBonusInfo.RewardCounter));
        }
        if (PlayerPrefs.HasKey(nameof(_weeklyBonusInfo.ReceivedRewardTime)))
        {
            _weeklyBonusInfo.ReceivedRewardTime = DateTime.Parse(PlayerPrefs.GetString(nameof(_weeklyBonusInfo.ReceivedRewardTime)));
        }

        _rewardReminder.SetActive(_weeklyBonusInfo.IsRewardAvailable);
        StartCoroutine(RewardTime());
    }

    private void TicketsChangedHandler(int tickets)
    {
        _ticketsText.text = tickets.ToString();
    }

    private IEnumerator RewardTime()
    {
        while (true)
        {
            _weeklyBonusInfo.CheckReward();
            _rewardReminder.SetActive(_weeklyBonusInfo.IsRewardAvailable);
            
            yield return new WaitForSeconds(UPDATE_TIME);
        }
    }

    public void OnRewardButtonClicked()
    {
        _rewardReminder.SetActive(_weeklyBonusInfo.IsRewardAvailable);
    }
}
