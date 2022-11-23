using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, IPlayer, IPowerUp
{
    [SerializeField] private ParticleSystem _boom;

    public void StartTank()
    {
        gameObject.SetActive(true);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.IsInvencible = true;
        PowerUpManager.Instance.ActualPowerUp = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.gameObject?.GetComponent<IAffectTank>();
        if (col != null)
        {
            CoinManager.Instance.AddMuchCoins(PowerUpManager.Instance.CoinsPerHit);
            ParticleSystem particle = Instantiate(_boom);
            particle.transform.position = other.transform.position + new Vector3(0, 2);
            particle.Play();
            Destroy(particle, 3);
            col.TankHit();
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.IsInvencible = false;
    }
}
