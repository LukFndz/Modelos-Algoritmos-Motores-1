using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EntityMovement
{
    private IAdvance _currentStrategy;

    public void ManualStart()
    {
        EventManager.Instance.Subscribe(EventManager.NameEvent.Gameover, StopMoving);
    }

    public void ManualUpdate()
    {
        _currentStrategy.Advance();
    }

    public void SetStrategy(IAdvance strategy) //SETEA LA ESTRATEGIA QUE SE VA UTILIZAR
    {
        _currentStrategy = strategy;
    }

    public void StopMoving(params object[] parameters)
    {
        _currentStrategy.Stop();
    } 
}
