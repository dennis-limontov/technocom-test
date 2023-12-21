using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Image _musicImage;

    [SerializeField]
    private Image _soundsImage;

    [SerializeField]
    private Sprite _musicSprite;

    [SerializeField]
    private Sprite _mutedMusicSprite;

    [SerializeField]
    private Sprite _soundsSprite;

    [SerializeField]
    private Sprite _mutedSoundsSprite;

    public void OnMusicClicked()
    {
        AudioController.Instance.MuteMusic();
        if (AudioController.Instance.IsMusicMuted)
        {
            _musicImage.sprite = _mutedMusicSprite;
        }
        else
        {
            _musicImage.sprite = _musicSprite;
        }
    }

    public void OnSoundsClicked()
    {
        AudioController.Instance.MuteSounds();
        if (AudioController.Instance.IsSoundMuted)
        {
            _soundsImage.sprite = _mutedSoundsSprite;
        }
        else
        {
            _soundsImage.sprite = _soundsSprite;
        }
    }
}