using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer
{
    public static readonly Flyweight Entity = new Flyweight
    {
        velocity = MovementManager.Instance.GetEntityVelocity()
    };

    public static readonly Flyweight Tile = new Flyweight
    {
        velocity = TileManager.Instance.GetTilesVelocity()
    };
}
