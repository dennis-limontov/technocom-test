using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    private LevelButton[] _levelsButtons;

    private void Start()
    {
        _levelsButtons = GetComponentsInChildren<LevelButton>();
        Array.Sort(_levelsButtons, (x, y) => (x.ButtonLevel - y.ButtonLevel));
        GameCharacteristics.OnCurrentLevelChanged += CurrentLevelChangedHandler;
    }

    private void CurrentLevelChangedHandler(int newLevel)
    {
        _levelsButtons[newLevel - 1].GetComponent<Image>().color = Color.white;
        _levelsButtons[newLevel].GetComponent<Image>().color = Color.green;
        _levelsButtons[newLevel].GetComponent<Button>().interactable = true;
    }
}