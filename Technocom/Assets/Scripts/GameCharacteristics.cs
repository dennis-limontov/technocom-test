using System;

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
            OnCurrentLevelChanged?.Invoke(_currentLevel);
        }
    }
}