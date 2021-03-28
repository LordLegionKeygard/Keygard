using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour
{
    

    public GameObject optionsMenuUI;
    public GameObject pauseMenuUI;
    public GameObject pauseCanvas;

    public void BackHandler()
    {
        pauseCanvas.SetActive(true);
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);       
    }
}
