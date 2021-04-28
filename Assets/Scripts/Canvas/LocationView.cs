using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationView : MonoBehaviour
{
    public Button Button;

    private void Reset() 
    {
        Button = GetComponent<Button>();
    }
}
