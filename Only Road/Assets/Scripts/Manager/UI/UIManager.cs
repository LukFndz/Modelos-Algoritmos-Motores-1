using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public enum PanelType
{
    LAST_MENU,
    MAIN_MENU,
    IN_GAME_MENU,
    PAUSE_MENU,
    INVENTORY_MENU,
    OPTIONS_MENU,
    HELP_MENU,
    END_MENU
}


public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI[] _txtHighScore;
    [SerializeField] private TextMeshProUGUI[] _txtCoins;

    public List<PanelManager> canvasControllerList;
    PanelManager actualActiveCanvas;
    PanelManager lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(PanelType.MAIN_MENU);
    }

    private void Start()
    {
        if (!SavePlayerDataJSON.Instance.Savedata.firstTime)
            SwitchCanvas(PanelType.HELP_MENU);
    }

    public PanelManager GetLastCanvas()
    {
        return lastActiveCanvas;
    }

    public void SwitchCanvas(PanelType _type)
    {
        if (actualActiveCanvas != null)
        {
            actualActiveCanvas.gameObject.SetActive(false);
        }

        PanelManager desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = actualActiveCanvas;
            actualActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("No se encontro el panel"); }
    }

    public void SetCoins()
    {
        foreach(TextMeshProUGUI tm in _txtCoins)
            tm.text = CoinManager.Instance.GetCoins().ToString();
    }

    public void SetHighScore()
    {
        foreach (TextMeshProUGUI tm in _txtHighScore)
            tm.text = "HI: " + ScoreManager.Instance.GetHighscore().ToString("N0") + "mts";
    }

    public void ChangeScore(float newScore)
    {
        _txtScore.text = newScore.ToString("N0") + "mts";
    }

    public void UpdateAllTxt()
    {
        SetCoins();
        SetHighScore();
    }

    //public void ChangeSprite(GameObject g, Image img)
    //{
    //    g.GetComponent<Image>().sprite = img.sprite;
    //}

    //public void ChangeAlpha(GameObject g, float alpha)
    //{
    //    var img = g.GetComponent<Image>().color;
    //    g.GetComponent<Image>().color = new Color(img.r,img.g,img.b, alpha);
    //}
}
