using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvanceTile : NormalAdvance
{
    public NormalAdvanceTile(Rigidbody rb, GameObject entity) : base(rb, entity)
    {
        _velocity = -FlyweightPointer.Tile.velocity;
    }
}
