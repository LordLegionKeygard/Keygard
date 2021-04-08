using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopStaffButton : MonoBehaviour
{
    public ShopCanvas shop;

    public StaffType type;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetStaff);
    }

    private void SetStaff()
    {
        shop.SetCurrentStaff(type);
    }
}

