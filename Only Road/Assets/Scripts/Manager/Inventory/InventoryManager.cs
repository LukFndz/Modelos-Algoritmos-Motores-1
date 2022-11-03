using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Map
{
    public string name;
    public GameObject map;
    public GameObject player;
    public Color skyColor;
    public int price;
    public bool unlocked;
}

public class InventoryManager : Singleton<InventoryManager>
{
    [Header("Maps")]
    [SerializeField] private Map[] _maps;
    [SerializeField] private Camera _cam;

    [Header("Spawn Pivots")]
    [SerializeField] private GameObject _mapPivot;
    [SerializeField] private GameObject _playerPivot;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI _txtMapName;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _inventoryButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMPro.TextMeshProUGUI _txtPrice;


    private GameObject _placeholderMap;
    private GameObject _placeholderPlayer;

    private GameObject _currentMap;
    private GameObject _currentPlayer;

    private int _currentIndex;
    private int index;

    private void Start()
    {
        _currentMap = Instantiate(_maps[index].map, _mapPivot.transform);
        _currentPlayer = Instantiate(_maps[index].player, _playerPivot.transform);
        _cam.backgroundColor = _maps[index].skyColor;
        _txtMapName.text = _maps[index].name;
        _currentIndex = index;
        _backButton.onClick.AddListener(BackToLastMap);
        _buyButton.onClick.AddListener(BuyMap);
        _inventoryButton.onClick.AddListener(OpenInventory);
        _txtPrice.text = _maps[index].price.ToString();
    }

    public void OpenInventory()
    {
        UIManager.Instance.SetCoins();
    }

    public void NextMap()
    {
        if (index < _maps.Length - 1)
        {
            index++;
            ChangeMap(index);
        }
        CheckButton();
    }

    public void LastMap()
    {
        if(index != 0)
        {
            index--;
            ChangeMap(index);
        }
        CheckButton();
    }

    public void ChangeMap(int index)
    {
        _currentMap.SetActive(false);
        _currentPlayer.SetActive(false);
        Destroy(_placeholderMap);
        Destroy(_placeholderPlayer);
        _placeholderMap = Instantiate(_maps[index].map, _mapPivot.transform);
        _placeholderPlayer = Instantiate(_maps[index].player, _playerPivot.transform);
        _txtMapName.text = _maps[index].name;
        _cam.backgroundColor = _maps[index].skyColor;
    }

    public void BackToLastMap()
    {
        if (_placeholderMap != null)
        {
            Destroy(_placeholderMap);
            Destroy(_placeholderPlayer);
        }
        _selectButton.gameObject.SetActive(false);
        _currentMap.SetActive(true);
        _currentPlayer.SetActive(true);
        index = _currentIndex;
        _txtMapName.text = _maps[index].name;
        _cam.backgroundColor = _maps[index].skyColor;
    }

    public void BuyMap()
    {
        if(CoinManager.Instance.GetCoins() >= _maps[index].price)
        {
            _maps[index].unlocked = true;
            CoinManager.Instance.AddMuchCoins(-_maps[index].price);
            UIManager.Instance.SetCoins();
            CheckButton();
        }
    }

    public void ConfirmMap()
    {
        Destroy(_currentMap);
        Destroy(_currentPlayer);
        _currentMap = _placeholderMap;
        _currentPlayer = _placeholderPlayer;
        _currentIndex = index;
        _placeholderMap = null;
        _placeholderPlayer = null;
        _selectButton.gameObject.SetActive(false);
    }

    public void CheckButton()
    {
        if(!_maps[index].unlocked)
        {
            _selectButton.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(true);
            _txtPrice.text = _maps[index].price.ToString();
        } else
        {
            _buyButton.gameObject.SetActive(false);
            if (index == _currentIndex)
                _selectButton.gameObject.SetActive(false);
            else
                _selectButton.gameObject.SetActive(true);
        }
    }
}
