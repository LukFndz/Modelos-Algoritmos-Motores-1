using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerComponent
{
    public void SetInput(float value)
    {
        _player.MyModel.MovementController.Input = new Vector3(0, 0, value);
    }
}
