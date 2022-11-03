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

    //UI
    public float musicVolume;
    public float effectVolume;
}
