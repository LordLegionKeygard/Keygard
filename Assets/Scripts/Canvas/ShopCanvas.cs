using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private StaffInfo _defaultStaff;

    public StaffInfo currentStaff;

    [SerializeField] private Button _equip;

    [SerializeField] private Button _buy;

    [SerializeField] private Text _textCoins;

    [SerializeField] private GameObject _startMenu;

    [SerializeField] private GameObject _shopCanvas;

    [SerializeField] private List<StaffObjects> staffObjects;

    [SerializeField] private List<StaffObjects> equipedObjects;

    private List<StaffInfo> _allStaffs = new List<StaffInfo>();

    [SerializeField] private List<StaffInfo> deafaultStaffInfo;

    private int _coins;

    private StaffInfo currentEquipedStaff = new StaffInfo();

    [SerializeField] private int _defaultCoins;

    private void Start()
    {
        Load();
        currentStaff = currentEquipedStaff;
        UpdateView();
        _buy.onClick.AddListener(Buy);
        _equip.onClick.AddListener(Equip);
    }

    private void Equip()
    {
        currentEquipedStaff = currentStaff;
        UpdateView();
        Save();
    }

    private void Buy()
    {
        if (currentStaff.price <= _coins)
        {
            currentStaff.bought = true;
            _coins -= currentStaff.price;
            UpdateView();
            Save();
        }
    }

    private void Save()
    {
        SaveCoins();
        SaveCurrentStaff();
        SaveAllStaffs();
        PlayerPrefs.Save();
    }

    private void SaveAllStaffs()
    {
        AllStaffSaveData saveData = new AllStaffSaveData() { Staffs = _allStaffs };
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("AllStaffs", json);
    }

    private void SaveCurrentStaff()
    {
        string json = JsonUtility.ToJson(currentStaff);
        PlayerPrefs.SetString("Staff", json);
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
        LoadCurrentStaff();
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

    private void LoadCurrentStaff()
    {
        string defaultStaff = JsonUtility.ToJson(_defaultStaff);
        string json = PlayerPrefs.GetString("Staff", defaultStaff);
        JsonUtility.FromJsonOverwrite(json, currentEquipedStaff);
    }

    private void UpdateView()
    {
        _textCoins.text = _coins.ToString();
        bool canBought = currentStaff.bought ? false : currentStaff.price <= _coins;
        _buy.interactable = canBought;
        _equip.interactable = currentStaff != currentEquipedStaff && currentStaff.bought;

        foreach (var staffObject in staffObjects)
        {
            if (staffObject.staffType == currentStaff.staffType)
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
        currentStaff = _allStaffs.Find(info => info.staffType == newStaffType);
        UpdateView();
    }

    public void BackHandler()
    {
        _shopCanvas.SetActive(false);
        _startMenu.SetActive(true);
    }

    private void OnDisable() 
    {
        Save();        
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
    public List<StaffInfo> Staffs;
}

