using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField]private int _coins;

    private void Start()
    {
        _coins = SavePlayerDataJSON.Instance.Savedata.coins;
    }

    public int GetCoins()
    {
        return _coins;
    }

    internal void AddCoin()
    {
        _coins++;
    }
}
