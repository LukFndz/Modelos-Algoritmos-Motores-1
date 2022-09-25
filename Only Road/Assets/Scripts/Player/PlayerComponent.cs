using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent
{

    protected Player _player;
    public void SetContext(Player player)
    {
        _player = player;
        _player._awake += ManualAwake;
        _player._start += ManualStart;
        _player._update += ManualUpdate;
        _player._fixedUpdate += ManualFixedUpdate;
        _player._onDrawGizmos += ManualDrawGizmos;
    }

    public virtual void ManualAwake() { }

    public virtual void ManualStart() { }

    public virtual void ManualUpdate() { }

    public virtual void ManualFixedUpdate() { }

    public virtual void ManualDrawGizmos() { }
}
