using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvasMenu : MonoBehaviour
{
    public GameObject optionsMenuUI;    

    public void BackHandler()
    {
        optionsMenuUI.SetActive(false);       
    }
}
