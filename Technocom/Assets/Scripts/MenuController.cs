using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ticketsText;

    [SerializeField]
    private Image _rewardReminder;

    [SerializeField]
    private WeeklyBonusInfo _weeklyBonusInfo;

    private const float TIME_UPDATE = 10f;

    private void OnDestroy()
    {
        GameCharacteristics.OnTicketsChanged -= TicketsChangedHandler;
    }

    private void Start()
    {
        GameCharacteristics.OnTicketsChanged += TicketsChangedHandler;
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
            if (_weeklyBonusInfo.IsRewardAvailable)
            {
                _rewardReminder.gameObject.SetActive(true);
            }
            
            yield return new WaitForSeconds(TIME_UPDATE);
        }
    }

    public void OnRewardButtonClicked()
    {
        if (_weeklyBonusInfo.IsRewardAvailable)
        {
            _rewardReminder.gameObject.SetActive(false);
        }
    }
}
