using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : CollectionableItem
{
    public override void GetItem()
    {
        CoinManager.Instance.AddCoin();
        EventManager.Instance.Trigger(EventManager.NameEvent.ChangeSoundEffect, "Coin");
        UIManager.Instance.SetCoins();
        base.GetItem();
    }
}
