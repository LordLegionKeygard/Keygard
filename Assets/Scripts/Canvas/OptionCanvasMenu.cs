using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvasMenu : MonoBehaviour
{
    public GameObject AreYouSurePanel;
    public GameObject optionsMenuUI; 
    public GameObject btn;

    public void BackHandler()
    {
        optionsMenuUI.SetActive(false);
        btn.SetActive(true);       
    }

    public void  ResetGameHandler()
    {
        AreYouSurePanel.SetActive(true);
    }
}


