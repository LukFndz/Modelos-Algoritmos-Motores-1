using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectionableType
{
    COIN,
    POWER_UP
}

public class CollectionableItem : MonoBehaviour
{
    [Range(10,30)]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _model;
    [SerializeField] private CollectionableType _type;

    void Update()
    {
        _model.transform.Rotate(0, (_rotationSpeed * 10) * Time.deltaTime , 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (_type)
            {
                case CollectionableType.COIN:
                    CoinManager.Instance.AddCoin();
                    AudioManager.Instance.ChangeEffect("Coin");
                    AudioManager.Instance.PlayOneShot();
                    UIManager.Instance.SetCoins();
                    break;
                case CollectionableType.POWER_UP:
                    PowerUpManager.Instance.ActivatePowerUp(GetComponent<PowerUp>().type);
                    break;
            }
            Entity.TurnOff(gameObject.GetComponent<Entity>());
        }
    }
}