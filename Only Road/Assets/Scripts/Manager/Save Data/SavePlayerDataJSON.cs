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
        LoadParams();
    }

    private void Start()
    {
        path = Application.persistentDataPath + "/mySave.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            LoadParams();
    }

    public void SaveParams(int coins, float score)
    {
        _savedata.coins = coins;
        if(_savedata.highscore < score)
            _savedata.highscore = coins;

        string json = JsonUtility.ToJson(_savedata, true);

        File.WriteAllText(path, json);
    }

    public void LoadParams()
    {
        if (!File.Exists(path)) return;
        else _savedata.coins = 0; _savedata.highscore = 0;

        string json = File.ReadAllText(path);

        _savedata = JsonUtility.FromJson<SaveData>(json);
    }
}
