using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour, IPowerUp, IInvencible
{

    public void Disable()
    {
        UIManager.Instance.StateExtra(false);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.DisableInvencible();
        CoinManager.Instance.AddMuchCoins(PowerUpManager.Instance.CoinsPerHit);
        ParticleSystem particle = PowerUpManager.Instance.Player.MyView.ExtraLife();
        particle.transform.position = PowerUpManager.Instance.Player.transform.position + new Vector3(0, 2);
        particle.Play();
        Destroy(particle, 3);
    }

    public void Touch(GameObject col)
    {
        Disable();
        var colission = col.gameObject?.GetComponent<IAffectTank>();
        if (col != null)
        {
            colission.TankHit();
        }
    }
}
