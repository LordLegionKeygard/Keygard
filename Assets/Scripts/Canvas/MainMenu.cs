using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsUI;
    public GameObject shopUI;
    public GameObject loadingScreen;
    public GameObject loading;
    public GameObject press;
    public GameObject _allButtons;
    public GameObject _locationsSelectionCanvas;
    public GameObject _gameLogo;


    public Slider bar;

    public void StartHandler()
    {
        _locationsSelectionCanvas.SetActive(true);
        _allButtons.SetActive(false);
        _gameLogo.SetActive(false);
    }
    
    public void OptionsHandler()
    {       
        optionsUI.SetActive(true);
        _allButtons.SetActive(false);
        _gameLogo.SetActive(false);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }

    public void ShopHandler()
    {
        shopUI.SetActive(true);
        _allButtons.SetActive(false);
        _gameLogo.SetActive(false);
    }
}
