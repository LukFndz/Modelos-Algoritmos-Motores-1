using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableItem : MonoBehaviour
{
    [Range(10, 30)]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _model;

    void Update()
    {
        _model.transform.Rotate(0, (_rotationSpeed * 10) * Time.deltaTime, 0); //ROTA CONSTANTEMENTE EL ITEM 
    }

    public virtual void GetItem()
    {
        Entity.TurnOff(gameObject.GetComponent<Entity>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IPlayer>() != null)
        {
            GetItem();
        }
    }
}