using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject loading;
    [SerializeField] private GameObject press;
    [SerializeField] private Slider _slider;
    [SerializeField] private int _level;

    public Button Button;
    private void Reset()
    {
        Button = GetComponent<Button>();
    }

    
    public void LevelHandler()
    {
        loadingScreen.SetActive(true);
        
        Location.Instance.CurrentLevelNumber = _level;
        Location.Instance.Save();

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_level);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            _slider.value = asyncLoad.progress;
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
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


}
