using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartHandler()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OptionsHandler()
    {

    }

    public void ExitHandler()
    {
        Application.Quit();
    }
}
