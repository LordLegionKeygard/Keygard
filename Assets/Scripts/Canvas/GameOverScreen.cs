using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseCanvasUI;
    public GameObject lvlmusic;
    public GameObject skillcanvas;

    public void RestartHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void ExitHandler()
    {
        SceneManager.LoadScene(0);
    }
    void Start()
    {
        skillcanvas.SetActive(false);
        lvlmusic.SetActive(false);    
        pauseCanvasUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}