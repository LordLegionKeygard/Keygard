using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCanvasFalse : MonoBehaviour
{
    public GameObject _allCanvas;
    public AudioSource _loadingScreenMusic;
    public AudioSource _lvlMusic;

    void Start()
    {
        _lvlMusic.Stop();
        _loadingScreenMusic.Play();
        _allCanvas.SetActive(false);
    }
}
