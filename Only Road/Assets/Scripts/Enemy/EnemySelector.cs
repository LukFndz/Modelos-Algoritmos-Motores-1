using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector
{
    public static int SetEnemy(Enemy _enemy)
    {
        int strategy = 0;
        int lane = 0;

        if (lane == 0)
            strategy = Random.Range(0,2);

        _enemy.EnemyMovement.SetStrategy(lane, strategy);

        return lane;
    }
}
