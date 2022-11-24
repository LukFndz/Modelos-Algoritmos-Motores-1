using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, IPlayer, IPowerUp, IInvencible
{
    [SerializeField] private ParticleSystem _boom;

    public void StartTank()
    {
        gameObject.SetActive(true);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.SetInvencible(this);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.ActualPowerUp = this;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.DisableInvencible();
    }

    public void Touch(GameObject col)
    {
        var colission = col.gameObject?.GetComponent<IAffectTank>();
        if (col != null)
        {
            CoinManager.Instance.AddMuchCoins(PowerUpManager.Instance.CoinsPerHit);
            ParticleSystem particle = Instantiate(_boom);
            particle.transform.position = col.transform.position + new Vector3(0, 2);
            particle.Play();
            Destroy(particle, 3);
            colission.TankHit();
        }
    }
}
