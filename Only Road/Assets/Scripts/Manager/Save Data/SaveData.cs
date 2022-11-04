using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct SaveData
{
    public bool firstTime;
    public int coins;
    public float highscore;
    public Map[] unlockedMaps;
    public int lastMapIndex;
    public int currentStamina;
    public string _lastStamina;
    public string _nextStamina;

    //UI
    public float musicVolume;
    public float effectVolume;
}
