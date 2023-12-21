using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _music;

    [SerializeField]
    private AudioSource _sound;

    [SerializeField]
    private AudioClip _sound1;

    [SerializeField]
    private AudioClip _sound2;

    public static AudioController Instance { get; private set; }

    private Dictionary<SoundName, AudioClip> _audioClips;

    public bool IsMusicMuted => _music.mute;

    public bool IsSoundMuted => _sound.mute;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(this);
        }

        _audioClips = new Dictionary<SoundName, AudioClip>()
        {
            { SoundName.Sound1, _sound1 },
            { SoundName.Sound2, _sound2 }
        };
    }

    public void MuteMusic()
    {
        _music.mute = !_music.mute;
    }

    public void MuteSounds()
    {
        _sound.mute = !_sound.mute;
    }

    private void Play(AudioClip clip)
    {
        _sound.PlayOneShot(clip);
    }

    public void Play(SoundName clip)
    {
        Play(_audioClips[clip]);
    }

    public enum SoundName
    {
        Sound1,
        Sound2,
    }
}