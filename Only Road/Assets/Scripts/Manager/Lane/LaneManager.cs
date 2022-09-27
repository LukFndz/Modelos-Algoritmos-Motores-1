using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : Singleton<LaneManager>
{
    private List<int> _lastLanes;
    [SerializeField] private float _spawnTime;

    public List<int> GetLastLanes()
    {
        return _lastLanes;
    }
}
