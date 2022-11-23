using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] private Map[] _maps;
    [SerializeField] private int _currentIndex;

    public Map[] Maps { get => _maps; set => _maps = value; }

    public void Awake()
    {
        base.Awake();
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, ChangeMap);
    }

    public void ChangeMap(params object[] parameters)
    {
        _maps[(int)parameters[0]].map.SetActive(true);
        _maps[(int)parameters[0]].player.SetActive(true);
        if ((int)parameters[0] != _currentIndex)
        {
            _maps[_currentIndex].map.SetActive(false);
            _maps[_currentIndex].player.SetActive(false);
        }
        _currentIndex = (int)parameters[0];

    }
}
