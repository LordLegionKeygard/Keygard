using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public GameObject _levels;
    public GameObject _locationImage;

    public void BackHandler()
    {
        _levels.SetActive(false);
        _locationImage.SetActive(true);
    }
}
