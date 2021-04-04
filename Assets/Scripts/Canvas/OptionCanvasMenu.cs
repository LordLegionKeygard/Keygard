using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvasMenu : MonoBehaviour
{
    public GameObject optionsMenuUI; 
    public GameObject _start;
    public GameObject _options;
    public GameObject _exit;
    public GameObject _shop;
    public GameObject _coin;    

    public void BackHandler()
    {
        optionsMenuUI.SetActive(false);
        _start.SetActive(true);
        _options.SetActive(true);
        _exit.SetActive(true);
        _shop.SetActive(true);
        _coin.SetActive(true);        
    }
}
