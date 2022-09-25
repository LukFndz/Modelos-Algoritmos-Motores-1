using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement
{
    IAdvance _currentStrategy;

    public void ManualUpdate()
    {
        _currentStrategy.Advance();
    }

    public void SetStrategy(IAdvance strategy)
    {
        _currentStrategy = strategy;
    }

    //PREGUNTAR SI USAR BUILDER PARA LA STRATEGY EN MOVEMENT
}
