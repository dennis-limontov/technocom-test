using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/WeeklyBonusInfo")]
public class WeeklyBonusInfo : ScriptableObject
{
    private int _rewardCounter = 0;
    public int RewardCounter
    {
        get { return _rewardCounter; }
        set
        {
            _rewardCounter = value;
            PlayerPrefs.SetInt(nameof(RewardCounter), _rewardCounter);
        }
    }

    private bool _isRewardAvailable = true;
    public bool IsRewardAvailable => _isRewardAvailable;

    private DateTime _receivedRewardTime;
    public DateTime ReceivedRewardTime
    {
        get { return _receivedRewardTime; }
        set
        {
            _receivedRewardTime = value;
            _isRewardAvailable = false;
            PlayerPrefs.SetString(nameof(ReceivedRewardTime), _receivedRewardTime.ToString());
        }
    }

    public void CheckReward()
    {
        if ((int)(DateTime.Now - _receivedRewardTime).TotalDays == 1)
        {
            _isRewardAvailable = true;
        }
        else if ((int)(DateTime.Now - _receivedRewardTime).TotalDays > 1)
        {
            _isRewardAvailable = true;
            RewardCounter = 0;
        }
    }
}