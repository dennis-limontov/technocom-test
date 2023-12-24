using UnityEngine;
using UnityEngine.UI;

public class LevelsMapGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject _roadFragment;

    [SerializeField]
    private Button _levelButton;

    private const int EVEN_ROAD_LEVEL_LIMIT = 4;
    private const int ODD_ROAD_LEVEL_LIMIT = 3;

    private (Vector2 max, Vector2 min)[] _levelsAnchors =
    {
        // even
        (new Vector2(0.66f, 0.23f), new Vector2(0.64f, 0.21f)),
        (new Vector2(0.21f, 0.29f), new Vector2(0.19f, 0.27f)),
        (new Vector2(0.31f, 0.75f), new Vector2(0.29f, 0.73f)),
        (new Vector2(0.74f, 0.82f), new Vector2(0.72f, 0.8f)),
        // odd
        (new Vector2(0.52f, 0.25f), new Vector2(0.5f, 0.23f)),
        (new Vector2(0.18f, 0.56f), new Vector2(0.16f, 0.54f)),
        (new Vector2(0.74f, 0.8f), new Vector2(0.72f, 0.78f))
    };

    private void Awake()
    {
        int roadFragmentsTotal = Mathf.CeilToInt(GameCharacteristics.LEVEL_MAX
            * 2f / (EVEN_ROAD_LEVEL_LIMIT + ODD_ROAD_LEVEL_LIMIT));
        for (int i = 0; i < roadFragmentsTotal; i++)
        {
            GameObject currentRoad = Instantiate(_roadFragment, transform);
            CreateLevelsButtons(currentRoad, i);
        }
    }

    private void CreateLevelsButtons(GameObject currentRoad, int index)
    {
        int localLevel = 1 + index * (EVEN_ROAD_LEVEL_LIMIT + ODD_ROAD_LEVEL_LIMIT) / 2;

        if (index % 2 == 0)
        {
            for (int i = 0; (i < EVEN_ROAD_LEVEL_LIMIT)
                && (localLevel <= GameCharacteristics.LEVEL_MAX); i++, localLevel++)
            {
                InstantiateLevelButton(currentRoad, localLevel);
            }
        }
        else
        {
            localLevel++;
            for (int i = 0; (i < ODD_ROAD_LEVEL_LIMIT)
                && (localLevel <= GameCharacteristics.LEVEL_MAX); i++, localLevel++)
            {
                InstantiateLevelButton(currentRoad, localLevel);
            }
        }
    }

    private void InstantiateLevelButton(GameObject currentRoad, int localLevel)
    {
        Button localLevelButton;
        int index = (localLevel - 1) % (EVEN_ROAD_LEVEL_LIMIT + ODD_ROAD_LEVEL_LIMIT);
        localLevelButton = Instantiate(_levelButton, currentRoad.transform);
        if (localLevel > GameCharacteristics.Instance.CurrentLevel)
        {
            localLevelButton.interactable = false;
        }
        else if (localLevel == GameCharacteristics.Instance.CurrentLevel)
        {
            localLevelButton.GetComponent<Image>().color = Color.green;
        }
        localLevelButton.GetComponent<RectTransform>().anchorMax = _levelsAnchors[index].max;
        localLevelButton.GetComponent<RectTransform>().anchorMin = _levelsAnchors[index].min;
        localLevelButton.GetComponent<LevelButton>().ButtonLevel = localLevel;
    }
}