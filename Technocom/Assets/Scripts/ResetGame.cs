using UnityEngine;

public class ResetGame : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}