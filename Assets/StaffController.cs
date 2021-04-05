using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaffController : MonoBehaviour
{
    [SerializeField] private StaffType _defaultStaff;

    [SerializeField] private List<StaffObjects> _staffObjects;
    
    [SerializeField] private List<StaffBehaviours> _staffBehaviours;

    private StaffInfo currentEquipedStaff = new StaffInfo();

    private void Start() 
    {
        Load();
        UpdateView();
    }

    private void Load()
    {
        AllStaffSaveData saveData = new AllStaffSaveData();
        string defaultStaffs = JsonUtility.ToJson(saveData);
        string json = PlayerPrefs.GetString("AllStaffs", defaultStaffs);
        JsonUtility.FromJsonOverwrite(json, saveData);
        var _allStaffs = saveData.Staffs;
        int indexEquipedStaff = PlayerPrefs.GetInt("Staff", (int) _defaultStaff);
        currentEquipedStaff = _allStaffs[indexEquipedStaff];
    }



    private void UpdateView()
    {
        foreach (var staffObject in _staffObjects)
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
        foreach (var staffBehaviour in _staffBehaviours)
        {
            if (staffBehaviour.staffType == currentEquipedStaff.staffType)
            {
                staffBehaviour.Activate();
            }
            else
            {
                staffBehaviour.DeActivate();
            }
        }
    }
}

[Serializable]
public class StaffBehaviours
{
    public StaffType staffType;

    public List<MonoBehaviour> Behaviours;

    public void Activate()
    {
        foreach (var item in Behaviours)
        {
            item.enabled = true;
        }
    }

    public void DeActivate()
    {
        foreach (var item in Behaviours)
        {
            item.enabled = false;
        }
    }
}
