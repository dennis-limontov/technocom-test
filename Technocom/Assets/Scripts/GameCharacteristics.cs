using System;
using UnityEngine;

public class GameCharacteristics
{
    public static GameCharacteristics Instance { get; private set; } = new GameCharacteristics();

    public const int LEVEL_MAX = 20;
    public const int NEW_GAME_TICKETS = 100;

    public static Action<int> OnTicketsChanged;
    public static Action<int> OnCurrentLevelChanged;

    private int _tickets = NEW_GAME_TICKETS;
    public int Tickets
    {
        get { return _tickets; }
        set
        {
            _tickets = value;
            PlayerPrefs.SetInt(nameof(Tickets), _tickets);
            OnTicketsChanged?.Invoke(_tickets);
        }
    }

    private int _currentLevel = 6;
    public int CurrentLevel
    {
        get { return _currentLevel; }
        set
        {
            _currentLevel = value;
            PlayerPrefs.SetInt(nameof(CurrentLevel), _currentLevel);
            OnCurrentLevelChanged?.Invoke(_currentLevel);
        }
    }
}