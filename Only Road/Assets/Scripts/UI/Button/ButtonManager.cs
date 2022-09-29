using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonManager : MonoBehaviour
{
    public PanelType desiredMenu;

    UIManager uiManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        uiManager = UIManager.Instance;
    }

    void OnButtonClicked()
    {
        if (desiredMenu != PanelType.LAST_MENU)
            uiManager.SwitchCanvas(desiredMenu);
        else
            uiManager.SwitchCanvas(uiManager.GetLastCanvas().canvasType);
    }
}
