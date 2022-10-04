using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : CollectionableItem, IPowerUp
{
    public override void GetItem()
    {
        Touch();
        base.GetItem();
    }

    public void Touch()
    {
        PowerUpManager.Instance.ActivatePowerUp(GetComponent<PowerUp>().type);
    }
}
