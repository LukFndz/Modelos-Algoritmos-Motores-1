using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private Camera _cam;

    private void Awake()
    {
        base.Awake();
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, ChangeSky);
    }

    public void ChangeSky(params object[] parameters)
    {
        _cam.backgroundColor = MapManager.Instance.Maps[(int)parameters[0]].skyColor;
    }
}
