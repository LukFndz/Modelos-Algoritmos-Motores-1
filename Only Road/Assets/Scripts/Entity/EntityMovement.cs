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

    public void ChangeVelocity(float newVel) //CAMBIA LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE (SE LO PASA A LA INTERFAZ)
    {
        _currentStrategy.ChangeVel(newVel); 
    }

    public float GetActualVelocity() //DEVUELVE LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE (SE LA PIDE A LA INTERFAZ)
    {
        return _currentStrategy.GetVelocity();
    }

    public void StopMoving(params object[] parameters)
    {
        ChangeVelocity(0);
    }

    
}
