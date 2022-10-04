using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private static bool isReload;

    private void Start()
    {
        if(isReload)
            gameObject.SetActive(false);
    }

    public void ChangeReload(bool state)
    {
        isReload = state;
    }
}
