using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodController : MonoBehaviour
{
    [SerializeField]
    private ShopItemInfo _shopItem;

    [SerializeField]
    private GameObject _shopItemPanel;

    [SerializeField]
    private GameObject _lockedPanel;

    [SerializeField]
    private TextMeshProUGUI _productText;

    [SerializeField]
    private TextMeshProUGUI _unlockLevelText;

    [SerializeField]
    private Button _purchaseButton;

    [SerializeField]
    private TextMeshProUGUI _priceWithCurrencyText;

    [SerializeField]
    private Image _boughtImage;

    private void OnDestroy()
    {
        GameCharacteristics.OnCurrentLevelChanged -= CurrentLevelChangedHandler;
    }

    private void Start()
    {
        GameCharacteristics.OnCurrentLevelChanged += CurrentLevelChangedHandler;
        CurrentLevelChangedHandler(GameCharacteristics.Instance.CurrentLevel);
        CheckIfBought();
        DefineShopItem();
    }

    private void CurrentLevelChangedHandler(int newLevel)
    {
        _shopItemPanel.SetActive(_shopItem.IsAvailable);
        _lockedPanel.SetActive(!_shopItem.IsAvailable);
        _purchaseButton.interactable = _shopItem.IsAvailable;
    }

    private void DefineShopItem()
    {
        _productText.text = _shopItem.Name;
        _unlockLevelText.text = _shopItem.UnlockLevel.ToString();
        if (_shopItem.ItemCurrency == ShopItemInfo.Currency.Money)
        {
            _priceWithCurrencyText.text = (_shopItem.Price / 100f).ToString() + "$";
        }
        else
        {
            _priceWithCurrencyText.text = _shopItem.Price.ToString();
        }
    }

    public void OnBuyClicked()
    {
        _shopItem.OnBought();
        CheckIfBought();
    }

    private void CheckIfBought()
    {
        _purchaseButton.gameObject.SetActive(!_shopItem.IsBought);
        _boughtImage.gameObject.SetActive(_shopItem.IsBought);
    }
}