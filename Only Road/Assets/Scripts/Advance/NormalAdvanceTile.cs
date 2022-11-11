using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvanceTile : NormalAdvance
{
    public NormalAdvanceTile(Rigidbody rb, GameObject entity) : base(rb, entity)
    {
        
    }
    public override void Advance()
    {
        _entity.transform.position += -(_entity.transform.right * (FlyweightPointer.Tile.velocity + TileManager.Instance.Multiplier) * Time.deltaTime) * breakGame;
    }
}
