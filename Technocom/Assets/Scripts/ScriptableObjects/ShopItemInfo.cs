using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ShopItemInfo")]
public class ShopItemInfo : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name => _name;

    [SerializeField]
    private int _unlockLevel;
    public int UnlockLevel => _unlockLevel;

    [SerializeField]
    private int _price;
    public int Price => _price;

    [SerializeField]
    private Currency _currency;
    public Currency ItemCurrency => _currency;

    public bool IsAvailable => (_unlockLevel <= GameCharacteristics.Instance.CurrentLevel);

    private bool _isBought;
    public bool IsBought
    {
        get => _isBought;
        set => _isBought = value;
    }

    public enum Currency
    {
        Money = 0,
        Tickets = 1
    }

    public virtual void OnBought()
    {
        if ((_currency == Currency.Tickets) && (GameCharacteristics.Instance.Tickets >= _price))
        {
            GameCharacteristics.Instance.Tickets -= _price;
            _isBought = true;
            PlayerPrefs.SetInt(_name, Convert.ToInt32(_isBought));
        }
    }
}