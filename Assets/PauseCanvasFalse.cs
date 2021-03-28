using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasFalse : MonoBehaviour
{
    public GameObject pauseCanvas;
    
    void Update()
    {
        UnityEngine.Cursor.visible = true;
        pauseCanvas.SetActive(false);        
    }
}
