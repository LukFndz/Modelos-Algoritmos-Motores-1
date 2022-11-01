using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField]private int _coins;

    private void Start()
    {
        SetCoinsFromSave();
        UIManager.Instance.SetCoins();
    }

    public void SetCoinsFromSave()
    {
        _coins = SavePlayerDataJSON.Instance.Savedata.coins;
    }

    public int GetCoins()
    {
        return _coins;
    }

    public void AddCoin()
    {
        _coins++;
    }

    public void AddMuchCoins(int quantity)
    {
        _coins += quantity;
        UIManager.Instance.SetCoins();
        SavePlayerDataJSON.Instance.SaveParams();
    }
}
