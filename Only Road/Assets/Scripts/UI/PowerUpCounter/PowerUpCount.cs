using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUpCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtPowerUp;

    float maxTime;
    float timer;
    private void Start()
    {
        maxTime = PowerUpManager.Instance.PowerUpTime;
        timer = maxTime;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            _txtPowerUp.text = timer.ToString("N2");
        }
        else
        {
            FinishPowerUpTimer();
        }
       
    }

    public void FinishPowerUpTimer()
    {
        timer = maxTime;
        UIManager.Instance.FinishPowerUpTimer();
        PowerUpManager.Instance.FinishPower();
    }
}
