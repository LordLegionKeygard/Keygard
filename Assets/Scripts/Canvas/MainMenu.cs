using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsUI;
    public GameObject loadingScreen;
    public GameObject loading;
    public GameObject press;

    public Slider bar;

    public void StartHandler()
    {
        loadingScreen.SetActive(true);
        //SceneManager.LoadScene(1);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                loading.SetActive(false);
                press.SetActive(true);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }

            }
            yield return null;
        }
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
