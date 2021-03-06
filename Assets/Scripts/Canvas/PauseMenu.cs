﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    //void Update()
    //{
        //UnityEngine.Cursor.visible = false;
        //if(Input.GetKeyDown(KeyCode.Escape))
       // {
         //   if (GameIsPaused)
         //   {
         //       UnityEngine.Cursor.visible = false;
          //      Resume();
         //   }
         //   else
          //  {
         //       UnityEngine.Cursor.visible = true;
         //       Pause();
          //  }
       // }
  //  }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void ExitHandler()
    {
        SceneManager.LoadScene(0);
    }
}
