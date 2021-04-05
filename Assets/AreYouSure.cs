using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreYouSure : MonoBehaviour
{
    public GameObject AreYouSurePanel;

    public void YesHandler()
    {
        PlayerPrefs.DeleteAll(); 
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0); 
    }

    public void NoHandler()
    {
        AreYouSurePanel.SetActive(false);
    }
}

