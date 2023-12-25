using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _scrollRect;

    private LevelButton[] _levelsButtons;

    private void OnDestroy()
    {
        GameCharacteristics.OnCurrentLevelChanged -= CurrentLevelChangedHandler;
    }

    private void Start()
    {
        _levelsButtons = GetComponentsInChildren<LevelButton>();
        Array.Sort(_levelsButtons, (x, y) => (x.ButtonLevel - y.ButtonLevel));
        GameCharacteristics.OnCurrentLevelChanged += CurrentLevelChangedHandler;
    }

    private void CurrentLevelChangedHandler(int newLevel)
    {
        if (newLevel <= GameCharacteristics.LEVEL_MAX)
        {
            _levelsButtons[newLevel - 2].GetComponent<Image>().color = Color.white;
            _levelsButtons[newLevel - 1].GetComponent<Image>().color = Color.green;
            _levelsButtons[newLevel - 1].GetComponent<Button>().interactable = true;
            /*
            var pos = 1 - ((_scrollRect.content.GetComponent<RectTransform>().rect.height / 2
                - _levelsButtons[newLevel - 1].transform.parent.localPosition.y)
                / _scrollRect.content.GetComponent<RectTransform>().rect.height);
            _scrollRect.normalizedPosition = new Vector2(0f, pos);*/
        }
    }
}