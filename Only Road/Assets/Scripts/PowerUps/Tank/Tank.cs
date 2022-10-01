using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            AudioManager.Instance.ChangeEffect("Explosion");
            AudioManager.Instance.PlayOneShot();
            _boom.transform.position = collision.transform.position + new Vector3(0, 2);
            _boom.Play();
            Entity.TurnOff(collision.gameObject.GetComponent<Entity>());
        }
    }
}
