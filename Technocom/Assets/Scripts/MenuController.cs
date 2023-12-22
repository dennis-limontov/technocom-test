using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Image _rewardReminder;

    private DateTime _receivedRewardTime;

    private int _rewardCounter = 0;

    public void OnRewardButtonClicked()
    {
        _rewardReminder.gameObject.SetActive(false);
        _receivedRewardTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
            DateTime.Now.Day);
        _rewardCounter++;
    }

    private void Start()
    {
        StartCoroutine(RewardTime());   
    }

    private IEnumerator RewardTime()
    {
        while (true)
        {
            if ((DateTime.Now - _receivedRewardTime).Days == 1)
            {
                _rewardReminder.gameObject.SetActive(true);
            }
            else if ((DateTime.Now - _receivedRewardTime).Days > 1)
            {
                _rewardReminder.gameObject.SetActive(true);
                _rewardCounter = 0;
            }
            yield return new WaitForSeconds(10f);
        }
    }
}
