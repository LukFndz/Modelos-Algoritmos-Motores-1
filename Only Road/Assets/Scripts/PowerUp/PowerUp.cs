using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerUpType
{
    TANK,
    ONLYCOINS
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType type;
}