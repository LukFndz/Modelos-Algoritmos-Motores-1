using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    [SerializeField] private AudioClip[] _effects;


    private Dictionary<string, AudioClip> _musicDictionary = new Dictionary<string, AudioClip>();

    private Dictionary<string, AudioClip> _effectDictionary = new Dictionary<string, AudioClip>();


    private void Awake()
    {
        base.Awake();
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, ChangeMusic);
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, PlayMusic);

        _musicDictionary.Clear();

        foreach (Map m in MapManager.Instance.Maps)
            AddMusicClip(m);
        foreach (AudioClip a in _effects)
            AddEffectClip(a.name, a);

    }

    private void Start()
    {
        _musicSource.volume = SavePlayerDataJSON.Instance.Savedata.musicVolume;
        _effectSource.volume = SavePlayerDataJSON.Instance.Savedata.effectVolume;
        

        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeSoundEffect, ChangeEffect);
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeSoundEffect, PlayOneShot);
    }

    public void ChangeMusic(params object[] parameters)
    {
        _musicSource.clip = _musicDictionary[MapManager.Instance.Maps[(int)parameters[0]].name];
    }

    public void ChangeEffect(params object[] parameters)
    {
        _effectSource.clip = _effectDictionary[(string)parameters[0]];
    }

    public void AddMusicClip(Map map)
    {
        _musicDictionary.Add(map.name, map.music);
    }

    public void AddEffectClip(string id, AudioClip clip)
    {
        _effectDictionary.Add(id, clip);
    }

    public void PlayMusic(params object[] parameters)
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