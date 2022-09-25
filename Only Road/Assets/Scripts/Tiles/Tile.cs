using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //COMPOSITION
    private EntityMovement _entityMovement;

    private void Start()
    {
        //APLICAR BUILDER?
        _entityMovement = new EntityMovement();
        _entityMovement.SetStrategy(new NormalAdvance(-TileManager.Instance.tilesVelocity * .01f, GetComponent<Rigidbody>(), gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        _entityMovement.ManualUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Limit"))
        {
            TileManager.Instance.TransportTile(gameObject);
        }
    }
}
