using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, IPlayer
{
    [SerializeField] private ParticleSystem _boom;

    private float _maxTime;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _maxTime)
        {
            DisableTank();
        }
    }


    public void StartTank()
    {
        gameObject.SetActive(true);
        _maxTime = PowerUpManager.Instance.PowerUpTime;
        PowerUpManager.Instance.Player.MyModel.PowerUpController.IsInvencible = true;
    }

    public void DisableTank()
    {
        _timer = 0;
        gameObject.SetActive(false);
        PowerUpManager.Instance.Player.MyModel.PowerUpController.IsInvencible = false;
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

}
