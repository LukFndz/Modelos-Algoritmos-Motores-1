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
        EventManager.Instance.Subscribe(EventManager.NameEvent.Gameover, SaveParams);
    }

    public void SaveParams(params object[] parameters)
    {
        _savedata.firstTime = true;
        int coins = CoinManager.Instance.GetCoins();
        float score = ScoreManager.Instance.GetScore();
        float musicVolume = AudioManager.Instance.GetActualVolume(SliderType.Music);
        float effectVolume = AudioManager.Instance.GetActualVolume(SliderType.Effects);
        Map[] unlockedMaps = InventoryManager.Instance.Maps;
        int index = InventoryManager.Instance.GetActualMapIndex();
        int stamina = StaminaManager.Instance.GetStamina();


        _savedata.effectVolume = effectVolume;
        _savedata.musicVolume = musicVolume;
        _savedata.unlockedMaps = unlockedMaps;
        _savedata.lastMapIndex = index;
        _savedata.currentStamina = stamina;
        _savedata._lastStamina = StaminaManager.Instance.GetLastDate();
        _savedata._nextStamina = StaminaManager.Instance.GetNextDate();

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
            _deleteSavedata.lastMapIndex = 0;
            _deleteSavedata.currentStamina = StaminaManager.Instance.MaxStamina;
            _deleteSavedata._lastStamina = DateTime.Now;
            _deleteSavedata._nextStamina = DateTime.Now;

            for (int i = 0; i < InventoryManager.Instance.Maps.Length; i++)
            {
                if(i != 0)
                    InventoryManager.Instance.Maps[i].unlocked = false;
            }

            _deleteSavedata.unlockedMaps = InventoryManager.Instance.Maps;
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
            _savedata.unlockedMaps = InventoryManager.Instance.Maps;
            _savedata.lastMapIndex = 0;
            _savedata.currentStamina = StaminaManager.Instance.MaxStamina;
            _savedata._lastStamina = DateTime.Now;
            _savedata._nextStamina = DateTime.Now;
            return;
        }

        string json = File.ReadAllText(path);

        _savedata = JsonUtility.FromJson<SaveData>(json);
    }
}
