using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SliderType{
    Effects,
    Music
}

public class AudioSlide : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private SliderType _type;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeVolume(_type, _slider.value));
        _slider.onValueChanged.AddListener(val => SavePlayerDataJSON.Instance.SaveParams());

        _slider.value = AudioManager.Instance.GetActualVolume(_type); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
