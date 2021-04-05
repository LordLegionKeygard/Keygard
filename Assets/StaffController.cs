using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaffController : MonoBehaviour
{
    [SerializeField] private StaffInfo _defaultStaff;

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
        string defaultStaff = JsonUtility.ToJson(_defaultStaff);
        string json = PlayerPrefs.GetString("Staff", defaultStaff);
        JsonUtility.FromJsonOverwrite(json, currentEquipedStaff);
        Debug.Log(currentEquipedStaff.staffType);
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
