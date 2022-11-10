using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //COMPOSITION
    private EntityMovement _entityMovement;

    private void Start()
    {
        _entityMovement = new EntityMovement();
        _entityMovement.SetStrategy(new NormalAdvanceTile(GetComponent<Rigidbody>(), gameObject));
        TileManager.Instance.Tiles.Add(this);
    }

    void Update()
    {
        _entityMovement.ManualUpdate();
    }

    public void ChangeVelocity(float newVel)
    {
        _entityMovement.ChangeVelocity(-newVel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Limit"))
        {
            TileManager.Instance.TransportTile(gameObject);
        }
    }
}
