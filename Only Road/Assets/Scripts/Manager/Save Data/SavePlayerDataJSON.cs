using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SavePlayerDataJSON : Singleton<SavePlayerDataJSON>
{

    [SerializeField]private SaveData _savedata = new SaveData();
    string path;

    public SaveData Savedata { get => _savedata; set => _savedata = value; }

    protected override void Awake()
    {
        base.Awake();
        path = Application.persistentDataPath + "/mySave.json";
        LoadParams();
    }

    private void Start()
    {
        EventManager.Subscribe(EventManager.NameEvent.Gameover, SaveParams);
    }

    public void SaveParams(params object[] parameters)
    {
        _savedata.firstTime = true;
        int coins = CoinManager.Instance.GetCoins();
        float score = ScoreManager.Instance.GetScore();
        float musicVolume = AudioManager.Instance.GetActualVolume(SliderType.Music);
        float effectVolume = AudioManager.Instance.GetActualVolume(SliderType.Effects);

        _savedata.effectVolume = effectVolume;
        _savedata.musicVolume = musicVolume;

        _savedata.coins = coins;
        if(_savedata.highscore < score)
            _savedata.highscore = score;

        WriteParams(_savedata);
    }

    public void WriteParams(SaveData save)
    {
        string json = JsonUtility.ToJson(save, true);

        File.WriteAllText(path, json);

        LoadParams();

        CoinManager.Instance.SetCoinsFromSave();
        ScoreManager.Instance.SetHighScoreFromSave();

        UIManager.Instance.UpdateAllTxt();
    }

    public void DeleteData()
    {
        if (File.Exists(path))
        {
            SaveData _deleteSavedata = new SaveData();
            _deleteSavedata.firstTime = false;
            _deleteSavedata.highscore = 0;
            _deleteSavedata.coins = 0;
            _deleteSavedata.musicVolume = 1;
            _deleteSavedata.effectVolume = 1;
            WriteParams(_deleteSavedata);
            return;
        }
    }

    public void LoadParams()
    {
        if (!File.Exists(path))
        {
            _savedata.firstTime = false;
            _savedata.coins = 0; 
            _savedata.highscore = 0;
            _savedata.musicVolume = 1;
            _savedata.effectVolume = 1;
            return;
        }

        string json = File.ReadAllText(path);

        _savedata = JsonUtility.FromJson<SaveData>(json);
    }
}
