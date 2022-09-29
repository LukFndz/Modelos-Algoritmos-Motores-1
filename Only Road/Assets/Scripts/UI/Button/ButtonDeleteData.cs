using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDeleteData : MonoBehaviour
{
    SavePlayerDataJSON saveManager;
    Button deleteButton;

    private void Start()
    {
        deleteButton = GetComponent<Button>();
        deleteButton.onClick.AddListener(OnButtonClicked);
        saveManager = SavePlayerDataJSON.Instance;
    }

    void OnButtonClicked()
    {
        saveManager.DeleteData();
    }
}
