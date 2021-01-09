using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCanvas : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject optionsMenuUI;
    public GameObject pauseMenuUI;


    

    public void BackHandler()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);       
    }
}
