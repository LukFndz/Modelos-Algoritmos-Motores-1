using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraObject : CollectionableItem, IPowerUpObject
{
    public override void GetItem()
    {
        Touch();
        base.GetItem();
    }

    public void Touch()
    {
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "PowerUp");
        PowerUpManager.Instance.Player.MyModel.PowerUpController.SetInvencible(new ExtraLife());
        UIManager.Instance.StateExtra(true);
    }
}
