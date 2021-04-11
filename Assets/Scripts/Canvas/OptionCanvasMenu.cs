using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvasMenu : MonoBehaviour
{
    public GameObject AreYouSurePanel;
    public GameObject optionsMenuUI; 
    public GameObject _allButtons;
    public GameObject _gameLogo;

    public void BackHandler()
    {
        optionsMenuUI.SetActive(false);
        _allButtons.SetActive(true);
        _gameLogo.SetActive(true);      
    }

    public void  ResetGameHandler()
    {
        AreYouSurePanel.SetActive(true);
    }
}


