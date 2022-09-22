using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySelector
{
    public static int SetEntity(Entity _entity)
    {
        int strategy = 0;
        int lane = Random.Range(0, 5);

        if (lane == 0)
            strategy = Random.Range(0, 2);

        Debug.Log("Strategy: " + strategy);
        Debug.Log("Lane: " + lane);

        _entity.EntityMovement.SetStrategy(lane, strategy);

        return lane;
    }
}
