using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private StaffType _defaultStaff;

    private StaffInfo _currentStaff;

    [SerializeField] private Button _equip;

    [SerializeField] private Button _buy;

    [SerializeField] private Text _textCoins;

    [SerializeField] private GameObject _allButtons;

    [SerializeField] private GameObject _gameLogo;

    [SerializeField] private GameObject _shopCanvas;

    [SerializeField] private List<StaffObjects> staffObjects;

    [SerializeField] private List<StaffObjects> equipedObjects;

    private List<StaffInfo> _allStaffs = new List<StaffInfo>();

    [SerializeField] private List<StaffInfo> deafaultStaffInfo;

    private int _coins;

    public GameObject AreYouSurePanel;

    private StaffInfo currentEquipedStaff = new StaffInfo();

    [SerializeField] private int _defaultCoins;

    private void Start()
    {
        Load();
        _currentStaff = currentEquipedStaff;
        UpdateView();
        _buy.onClick.AddListener(Buy);
        _equip.onClick.AddListener(Equip);
    }


    private void Equip()
    {
        currentEquipedStaff = _currentStaff;
        UpdateView();
        Save();
    }

    private void Buy()
    {
        if (_currentStaff.price <= _coins)
        {
            _currentStaff.bought = true;
            _coins -= _currentStaff.price;
            UpdateView();
            Save();
        }
    }

    private void Save()
    {
        SaveCoins();
        SaveEquipedStaff();
        SaveAllStaffs();
        PlayerPrefs.Save();
    }

    private void SaveAllStaffs()
    {
        AllStaffSaveData saveData = new AllStaffSaveData() { Staffs = _allStaffs };
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("AllStaffs", json);
    }

    private void SaveEquipedStaff()
    {
        int indexEquipedStaff = _allStaffs.IndexOf(currentEquipedStaff);
        PlayerPrefs.SetInt("Staff", indexEquipedStaff);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("coin", _coins);
    }

    private void LoadCoins()
    {
        _coins = PlayerPrefs.GetInt("coin", _defaultCoins);
    }

    private void Load()
    {
        LoadAllStaffs();
        LoadEquipedStaff();
        LoadCoins();
    }

    private void LoadAllStaffs()
    {
        AllStaffSaveData saveData = new AllStaffSaveData() { Staffs = deafaultStaffInfo };
        string defaultStaffs = JsonUtility.ToJson(saveData);
        string json = PlayerPrefs.GetString("AllStaffs", defaultStaffs);
        JsonUtility.FromJsonOverwrite(json, saveData);
        _allStaffs = saveData.Staffs;
    }

    private void LoadEquipedStaff()
    {
        int indexEquipedStaff = PlayerPrefs.GetInt("Staff", (int) _defaultStaff);
        currentEquipedStaff = _allStaffs[indexEquipedStaff];
    }

    private void UpdateView()
    {
        _textCoins.text = _coins.ToString();
        bool canBought = _currentStaff.bought ? false : _currentStaff.price <= _coins;
        _buy.interactable = canBought;
        _equip.interactable = _currentStaff != currentEquipedStaff && _currentStaff.bought;

        foreach (var staffObject in staffObjects)
        {
            if (staffObject.staffType == _currentStaff.staffType)
            {
                staffObject.Activate();
            }
            else
            {
                staffObject.DeActivate();
            }
        }

        foreach (var staffObject in equipedObjects)
        {
            if (staffObject.staffType == currentEquipedStaff.staffType)
            {
                staffObject.Activate();
            }
            else
            {
                staffObject.DeActivate();
            }
        }
    }

    public void SetCurrentStaff(StaffType newStaffType)
    {
        _currentStaff = _allStaffs.Find(info => info.staffType == newStaffType);
        UpdateView();
    }

    public void BackHandler()
    {
        _shopCanvas.SetActive(false);
        _allButtons.SetActive(true);
        _gameLogo.SetActive(true);
    }

    private void OnDisable() 
    {
        Save();
    }

    public void YesHandler()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Load();        
        SceneManager.LoadScene(0); 
    }

    public void NoHandler()
    {
        AreYouSurePanel.SetActive(false);
    }
}

[Serializable]
public class StaffObjects
{
    public StaffType staffType;
    public List<GameObject> objects;

    public void Activate()
    {
        foreach (var item in objects)
        {
            item.SetActive(true);
        }
    }

    public void DeActivate()
    {
        foreach (var item in objects)
        {
            item.SetActive(false);
        }
    }
}

[Serializable]
public class StaffInfo
{
    public StaffType staffType;
    public int price;
    public bool bought;
}

[Serializable]
public class AllStaffSaveData
{
    public List<StaffInfo> Staffs = new List<StaffInfo>();
}
