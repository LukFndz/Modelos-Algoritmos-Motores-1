using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy, IAffectTank
{
    public virtual void Touch()
    {
        GameManager.Instance.GameOver();
    }

    public void TankHit()
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "Explosion");
        Entity.TurnOff(gameObject.GetComponent<Entity>());
    }
}


