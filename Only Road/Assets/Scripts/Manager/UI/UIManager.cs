using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public enum PanelType
{
    LAST_MENU,
    MAIN_MENU,
    IN_GAME_MENU,
    PAUSE_MENU,
    INVENTORY_MENU,
    OPTIONS_MENU,
    HELP_MENU,
    END_MENU,
    REWARD_MENU
}


public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI[] _txtHighScore;
    [SerializeField] private TextMeshProUGUI[] _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtStamina;
    [SerializeField] private TextMeshProUGUI _txtTimer;

    [Header("PowerUp")]
    [SerializeField] private GameObject _powerUpOBJ;

    [Header("Inventory")]
    [SerializeField] private TextMeshProUGUI _txtMapName;
    [SerializeField] private TextMeshProUGUI _txtPrice;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _inventoryButton;
    [SerializeField] private Button _buyButton;

    public List<PanelManager> canvasControllerList;
    PanelManager actualActiveCanvas;
    PanelManager lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(PanelType.MAIN_MENU);

        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, ChangeMapName);
        EventManager.Instance.Subscribe(EventManager.NameEvent.ChangeMap, ChangePriceMap);

    }

    private void Start()
    {
        if (!SavePlayerDataJSON.Instance.Savedata.firstTime)
            SwitchCanvas(PanelType.HELP_MENU);

        _backButton.onClick.AddListener(InventoryManager.Instance.BackToLastMap);
        _buyButton.onClick.AddListener(InventoryManager.Instance.BuyMap);
        _inventoryButton.onClick.AddListener(InventoryManager.Instance.OpenInventory);

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

    public void StartPowerUpTimer()
    {
        _powerUpOBJ.SetActive(true);
    }

    public void FinishPowerUpTimer()
    {
        _powerUpOBJ.SetActive(false);
    }

    public void UpdateStamina()
    {
        _txtStamina.text = StaminaManager.Instance.GetStamina().ToString() + " / " + StaminaManager.Instance.MaxStamina.ToString();
    }

    public void UpdateStaminaTimer()
    {
        if (StaminaManager.Instance.GetStamina() >= StaminaManager.Instance.MaxStamina)
            _txtTimer.gameObject.SetActive(false);
        else
        {
            _txtTimer.gameObject.SetActive(true);
            TimeSpan timer = StaminaManager.Instance.GetNextDate() - DateTime.Now;
            _txtTimer.text = timer.Minutes.ToString() + ":" + timer.Seconds.ToString();
        }
    }

    public void ChangeMapName(params object[] parameters)
    {
        _txtMapName.text = MapManager.Instance.Maps[(int)parameters[0]].name;
    }

    public void ChangePriceMap(params object[] parameters)
    {
        _txtPrice.text = MapManager.Instance.Maps[(int)parameters[0]].price.ToString();
    }

    public void CheckButtonsInventory(int index, int currentMap)
    {
        if (!MapManager.Instance.Maps[index].unlocked)
        {
            _selectButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);
            _txtPrice.text = MapManager.Instance.Maps[index].price.ToString();
        }
        else
        {
            _buyButton.gameObject.SetActive(false);
            if (index == currentMap)
                _selectButton.gameObject.SetActive(false);
            else
                _selectButton.gameObject.SetActive(true);
        }
    }
    
    public void GoBackInventory(int index)
    {
        _selectButton.gameObject.SetActive(false);
        _txtMapName.text = MapManager.Instance.Maps[index].name;
    }

    public void SelectMap()
    {
        _selectButton.gameObject.SetActive(false);
    }

}
