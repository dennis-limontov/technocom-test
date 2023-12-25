using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ChestInfo")]
public class ChestInfo : ShopItemInfo
{
    [SerializeField]
    private int _tickets;
    public int Tickets => _tickets;

    public override void OnBought()
    {
        GameCharacteristics.Instance.Tickets += _tickets;
        // substrating money
    }
}