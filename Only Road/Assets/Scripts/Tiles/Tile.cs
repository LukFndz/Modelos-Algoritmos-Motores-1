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
        EventManager.Instance.Subscribe(EventManager.NameEvent.Gameover, StopMove);
    }

    void Update()
    {
        _entityMovement.ManualUpdate();
    }

    public void StopMove(params object[] parameters)
    {
        _entityMovement.StopMoving();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Limit"))
        {
            TileManager.Instance.TransportTile(gameObject);
        }
    }
}
