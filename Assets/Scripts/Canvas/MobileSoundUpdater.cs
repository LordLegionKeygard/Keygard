using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileSoundUpdater : MonoBehaviour
{
    public AudioManager.AudioChannel channel;
    private int vol = 100;

    public void UpdateSoundLevels()
    {
        if(vol == 100)
        {
            AudioManager.Instance.SetVolume(channel, 0);
            vol = 0;
        }
        else if(vol == 0)
        {
            AudioManager.Instance.SetVolume(channel, 100); 
            vol = 100;           
        }
    }   
}
