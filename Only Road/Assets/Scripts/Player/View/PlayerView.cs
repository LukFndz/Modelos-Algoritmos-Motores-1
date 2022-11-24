using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerView : PlayerComponent
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private ParticleSystem _extraLife;

    public override void ManualStart()
    {
        _player.OnDeath += Explosion;
    }

    public void Explosion()
    {
        _explosion.Play();
    }

    public ParticleSystem ExtraLife()
    {
        _extraLife.Play();
        return _extraLife;
    }
}
