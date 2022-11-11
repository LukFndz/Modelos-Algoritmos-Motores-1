using UnityEngine;

public class NormalAdvance : IAdvance
{
    private Rigidbody _rb;
    protected GameObject _entity;
    protected int breakGame = 1;

    public NormalAdvance(Rigidbody rb, GameObject entity)
    {
        _rb = rb;
        _entity = entity;
    }

    public virtual void Advance() //AVANZA LA VELOCIDAD A LA QUE AVANZA ACTUALMENTE
    {
        _entity.transform.position += (_entity.transform.right * (FlyweightPointer.Entity.velocity + MovementManager.Instance.Multiplier) * Time.deltaTime) * breakGame;
    }

    public void Stop()
    {
        breakGame = 0;
    }
}
