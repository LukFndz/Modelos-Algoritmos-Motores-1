using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : CollectionableItem, IPowerUpObject
{
    public override void GetItem()
    {
        Touch();
        base.GetItem();
    }

    public void Touch()
    {
        PowerUpManager.Instance.Player.MyModel.PowerUpController.Tank();
        PowerUpManager.Instance.ActivatePowerUp();
    }
}
