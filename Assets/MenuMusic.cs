using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMusic : MonoBehaviour
{
    public AudioSource MainMenu;

    void Start()
    {
        MenuuMusic();
    }

    public void MenuuMusic()
    {
        MainMenu.Play();
    }
}