using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    [SerializeField] private AudioClip[] _musics;
    [SerializeField] private AudioClip[] _effects;


    private Dictionary<string, AudioClip> _musicDictionary = new Dictionary<string, AudioClip>();

    private Dictionary<string, AudioClip> _effectDictionary = new Dictionary<string, AudioClip>();

    private void Start()
    {
        _musicSource.volume = SavePlayerDataJSON.Instance.Savedata.musicVolume;
        _effectSource.volume = SavePlayerDataJSON.Instance.Savedata.effectVolume;

        foreach (AudioClip a in _musics)
            AddMusicClip(a.name, a);
        foreach (AudioClip a in _effects)
            AddEffectClip(a.name, a);

        _musicSource.clip = _musicDictionary[TileManager.Instance.GetActualMap().ToString() + "Music"];
        PlayMusic();

        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeSoundEffect, ChangeEffect);
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeSoundEffect, PlayOneShot);
    }

    public void ChangeMusic(string id)
    {
        _musicSource.clip = _musicDictionary[id];
    }

    public void ChangeEffect(params object[] parameters)
    {
        _effectSource.clip = _effectDictionary[(string)parameters[0]];
    }

    public void AddMusicClip(string id, AudioClip clip)
    {
        _musicDictionary.Add(id, clip);
    }

    public void AddEffectClip(string id, AudioClip clip)
    {
        _effectDictionary.Add(id, clip);
    }

    public void PlayMusic()
    {
        _musicSource.Play();
    }

    public void PlayOneShot(params object[] parameters)
    {
        _effectSource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
    public void ChangeVolume(SliderType type, float val)
    {
        switch (type)
        {
            case SliderType.Effects:
                _effectSource.volume = val;
                break;
            case SliderType.Music:
                _musicSource.volume = val;
                break;
        }
    }

    public float GetActualVolume(SliderType type)
    {
        switch (type)
        {
            case SliderType.Effects:
                return _effectSource.volume;
                break;
            case SliderType.Music:
                return _musicSource.volume;
                break;
            default:
                return 0;
                break;
        }
    }
}