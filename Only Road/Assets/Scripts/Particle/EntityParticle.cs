using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityParticle : Entity
{
    public override void Start()
    {
        base.Start();
        _entityMovement.SetStrategy(new NormalAdvance(GetComponent<Rigidbody>(), this.gameObject));
    }

    public override void Update()
    {
        _entityMovement.ManualUpdate();
    }
}
