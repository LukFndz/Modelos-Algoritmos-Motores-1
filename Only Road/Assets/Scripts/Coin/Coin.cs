using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(10,30)]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _model;

    void Update()
    {
        _model.transform.Rotate(0, (_rotationSpeed * 10) * Time.deltaTime , 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin();
            Entity.TurnOff(gameObject.GetComponent<Entity>());
        }
    }
}
