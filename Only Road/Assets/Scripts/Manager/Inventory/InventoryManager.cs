using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Map
{
    public GameObject map;
    public GameObject player;
    public Color skyColor;
}

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private Map[] _maps;
    [SerializeField] private Camera _cam;

    [SerializeField] private GameObject _mapPivot;
    [SerializeField] private GameObject _playerPivot;

    
    private GameObject _currentMap;
    private GameObject _currentPlayer;
    private int index;

    private void Start()
    {
        _currentMap = Instantiate(_maps[index].map, _mapPivot.transform);
        _currentPlayer = Instantiate(_maps[index].player, _playerPivot.transform);
        _cam.backgroundColor = _maps[index].skyColor;
    }

    public void NextMap()
    {
        if (index < _maps.Length - 1)
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
        Destroy(_currentMap);
        Destroy(_currentPlayer);
        _currentMap = Instantiate(_maps[index].map, _mapPivot.transform);
        _currentPlayer = Instantiate(_maps[index].player, _playerPivot.transform);
        _cam.backgroundColor = _maps[index].skyColor;

    }
}
