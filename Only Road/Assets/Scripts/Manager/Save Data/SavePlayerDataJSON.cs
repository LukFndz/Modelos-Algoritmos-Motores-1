using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePlayerDataJSON : Singleton<SavePlayerDataJSON>
{

    [SerializeField]private SaveData _savedata = new SaveData();
    string path;

    public SaveData Savedata { get => _savedata; set => _savedata = value; }

    private void Awake()
    {
        base.Awake();
        path = Application.persistentDataPath + "/mySave.json";
        LoadParams();
    }

    public void SaveParams()
    {
        int coins = CoinManager.Instance.GetCoins();
        float score = ScoreManager.Instance.GetScore();

        _savedata.coins = coins;
        if(_savedata.highscore < score)
            _savedata.highscore = score;

        string json = JsonUtility.ToJson(_savedata, true);

        File.WriteAllText(path, json);
    }

    public void LoadParams()
    {
        if (!File.Exists(path))
        {
            _savedata.coins = 0; 
            _savedata.highscore = 0;
            return;
        }

        string json = File.ReadAllText(path);

        _savedata = JsonUtility.FromJson<SaveData>(json);
    }
}
