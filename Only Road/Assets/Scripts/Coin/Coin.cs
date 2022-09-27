using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Range(10,30)]
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        transform.Rotate(0, (_rotationSpeed * 10) * Time.deltaTime , 0);
    }
}
