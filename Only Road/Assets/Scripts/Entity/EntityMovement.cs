using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement
{
    private IAdvance _currentStrategy;

    public void ManualUpdate()
    {
        _currentStrategy.Advance();
    }

    public void SetStrategy(IAdvance strategy)
    {
        _currentStrategy = strategy;
    }

    public void ChangeVelocity(float newVel)
    {
        _currentStrategy.ChangeVel(newVel);
    }

    public float GetActualVelocity()
    {
        return _currentStrategy.GetVelocity();
    }

    //PREGUNTAR SI USAR BUILDER PARA LA STRATEGY EN MOVEMENT
}
