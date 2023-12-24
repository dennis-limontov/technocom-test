using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private int _buttonLevel;
    public int ButtonLevel
    {
        get => _buttonLevel;
        set { _buttonLevel = value; }
    }

    private TextMeshProUGUI _buttonLevelText;

    private void Start()
    {
        _buttonLevelText = GetComponentInChildren<TextMeshProUGUI>();
        _buttonLevelText.text = ButtonLevel.ToString();
    }

    public void OnButtonClicked()
    {
        if (ButtonLevel == GameCharacteristics.Instance.CurrentLevel)
        {
            GameCharacteristics.Instance.CurrentLevel++;
        }
    }
}