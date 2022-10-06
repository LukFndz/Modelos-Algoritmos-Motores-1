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
        _maxTime = PowerUpManager.Instance.TankTime;
    }

    public void DisableTank()
    {
        _timer = 0;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        var col = other.gameObject?.GetComponent<IAffectTank>();
        if (col != null)
        {
            _boom.transform.position = other.transform.position + new Vector3(0, 2);
            _boom.Play();
            col.TankHit();
        }
    }

}
