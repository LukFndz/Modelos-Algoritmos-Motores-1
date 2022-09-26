using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _txtScore;

    public void ChangeScore(float newScore)
    {
        _txtScore.text = newScore.ToString("N0") + "mts";
    }
}
