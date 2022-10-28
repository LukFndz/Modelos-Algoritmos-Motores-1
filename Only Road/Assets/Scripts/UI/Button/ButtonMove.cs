using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _value;

    private void Start()
    {
        //RectTransform rt = gameObject.GetComponent<RectTransform>();
        //rt.sizeDelta = new Vector2(Screen.height, (Screen.width / 2));
    }

    public void Move()
    {
        _player.MyController.SetInput(_value);
    }

    public void StopMove()
    {
        _player.MyController.SetInput(0);
    }
}
