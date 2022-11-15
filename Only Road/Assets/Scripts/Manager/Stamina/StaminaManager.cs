using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaminaManager : Singleton<StaminaManager>
{
    [SerializeField] private int _maxStamina;

    [SerializeField] private int _currentStamina;
    private bool _restoring;

    private bool _haveStamina;

    [SerializeField] private int timeToRecharge;

    private DateTime _nextStamina;
    private DateTime _lastStamina;

    [SerializeField] private int _playEnergy;

    public int MaxStamina { get => _maxStamina; set => _maxStamina = value; }
    public bool HaveStamina { get => _currentStamina > 0; }
    public int PlayEnergy { get => _playEnergy; set => _playEnergy = value; }

    private void Start()
    {
        LoadTime();
        UpdateStamina();
        UpdateTimer();
        StartCoroutine(RestoreStamina());
    }

    private IEnumerator RestoreStamina()
    {
        UpdateStamina();
        while (_currentStamina < _maxStamina)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = _nextStamina;
            bool _flagStamina = false;

            while (currentDateTime > _nextStamina)
            {
                if(_currentStamina < _maxStamina)
                {
                    _currentStamina++;
                    UpdateStamina();
                    _flagStamina = true;
                    DateTime timeToAdd = DateTime.Now;
                    if (_lastStamina > nextDateTime)
                        timeToAdd = _lastStamina;
                    else
                        timeToAdd = nextDateTime;

                    nextDateTime = AddDuration(timeToAdd, timeToRecharge);
                } else
                {
                    break;
                }
            }

            if(_flagStamina)
            {
                _lastStamina = DateTime.Now;
                _nextStamina = nextDateTime;
            }
            UpdateTimer();
            UpdateStamina();
            SavePlayerDataJSON.Instance.SaveParams();
            yield return new WaitForEndOfFrame();
        }
        _restoring = false;
    }

    public DateTime AddDuration(DateTime date, float value)
    {
        return date.AddSeconds(value);
    }

    public bool UseEnergy(int energyAmount)
    {
        if(_currentStamina - energyAmount >= 0)
        {
            _currentStamina -= energyAmount;
            UpdateStamina();

            if(!_restoring)
            {
                _nextStamina = AddDuration(DateTime.Now, timeToRecharge);
                StartCoroutine(RestoreStamina());
            }
            return true;
        } else
        {
            return false;
        }
    }

    void UpdateStamina()
    {
        UIManager.Instance.UpdateStamina();
    }

    void UpdateTimer()
    {
        UIManager.Instance.UpdateStaminaTimer();
    }

    public void LoadTime()
    {
        _currentStamina = SavePlayerDataJSON.Instance.Savedata.currentStamina;
        _nextStamina = DateTime.Parse(SavePlayerDataJSON.Instance.Savedata._nextStamina);
        _lastStamina = DateTime.Parse(SavePlayerDataJSON.Instance.Savedata._lastStamina);
    }

    public int GetStamina()
    {
        return _currentStamina;
    }

    public DateTime GetNextDate()
    {
        return _nextStamina;
    }
   
    public DateTime GetLastDate()
    {
        return _lastStamina;
    }
}
