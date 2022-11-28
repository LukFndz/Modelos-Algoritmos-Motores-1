using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Map
{
    public string name;
    public GameObject map;
    public GameObject player;
    public Color skyColor;
    public int price;
    public bool unlocked;
    public AudioClip music;
}

public class InventoryManager : Singleton<InventoryManager>
{

    private int _currentSelectedMap;
    private int index;

    private void Start()
    {
        SetMapsFromSave();
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeMap, SavePlayerDataJSON.Instance.Savedata.lastMapIndex);
        _currentSelectedMap = SavePlayerDataJSON.Instance.Savedata.lastMapIndex;

        index = _currentSelectedMap;

    }

    public void OpenInventory()
    {
        UIManager.Instance.SetCoins();
        UIManager.Instance.CheckButtonsInventory(index, _currentSelectedMap);
    }

    public void NextMap()
    {
        if (index < MapManager.Instance.Maps.Length - 1)
        {
            index++;
            ChangeMap(index);
        }
    }

    public void LastMap()
    {
        if(index != 0)
        {
            index--;
            ChangeMap(index);
        }
    }

    public void ChangeMap(int index)
    {
        UIManager.Instance.CheckButtonsInventory(index, _currentSelectedMap);
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeMap, index);

        //_currentMap.SetActive(false);
        //_currentPlayer.SetActive(false);
        //Destroy(_placeholderMap);
        //Destroy(_placeholderPlayer);
        //_txtMapName.text = _maps[index].name;
        //AudioManager.Instance.ChangeMusic(GetActualMap());
        //AudioManager.Instance.PlayMusic();
        //_cam.backgroundColor = _maps[index].skyColor;
    }

    public void BackToLastMap() //VUELVE AL MAPA 
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeMap, _currentSelectedMap);
        index = _currentSelectedMap;
        UIManager.Instance.GoBackInventory(index);

        //if (_placeholderMap != null)
        //{
        //    Destroy(_placeholderMap);
        //    Destroy(_placeholderPlayer);
        //}
        //_selectButton.gameObject.SetActive(false);
        //_currentMap.SetActive(true);
        //_currentPlayer.SetActive(true);
        //index = _currentSelectedMap;
        //_txtMapName.text = _maps[index].name;
        //_cam.backgroundColor = _maps[index].skyColor;
        //AudioManager.Instance.ChangeMusic(GetActualMap());
        //AudioManager.Instance.PlayMusic();
    }

    public void BuyMap()
    {
        if(CoinManager.Instance.GetCoins() >= MapManager.Instance.Maps[index].price)
        {
            MapManager.Instance.Maps[index].unlocked = true;
            CoinManager.Instance.AddMuchCoins(-MapManager.Instance.Maps[index].price);
            UIManager.Instance.SetCoins();
            UIManager.Instance.CheckButtonsInventory(index, _currentSelectedMap);
            SavePlayerDataJSON.Instance.SaveParams();
        }
    }

    public void ConfirmMap()
    {
        if (MapManager.Instance.Maps[index].unlocked)
        {
            _currentSelectedMap = index;
            UIManager.Instance.SelectMap();
            SavePlayerDataJSON.Instance.SaveParams();
        }
    }

    public int GetActualMapIndex()
    {
        return index;
    }

    public void SetMapsFromSave()
    {
        for (int i = 0; i < MapManager.Instance.Maps.Length; i++)
        {
            MapManager.Instance.Maps[i].unlocked = SavePlayerDataJSON.Instance.Savedata.unlockedMaps[i].unlocked;
        }
    }
}
