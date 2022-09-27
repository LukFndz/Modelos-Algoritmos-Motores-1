using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI _txtHighScore;

    public void SetHighScore()
    {
        _txtHighScore.text = "HI: " + ScoreManager.Instance.GetHighscore().ToString("N0") + "mts";
    }

    public void ChangeScore(float newScore)
    {
        _txtScore.text = newScore.ToString("N0") + "mts";
    }
}
