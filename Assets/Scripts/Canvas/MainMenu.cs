using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsUI;

    public void StartHandler()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OptionsHandler()
    {
        
        optionsUI.SetActive(true);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }
}
