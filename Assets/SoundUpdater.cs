using ChrisTutorials.Persistent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUpdater : MonoBehaviour
{
    public AudioManager.AudioChannel channel;
    public Text soundLevelsText;
    public string channelName = "Master Sound";


    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateSoundLevels()
    {
        int sliderValue = (int)(slider.value * 100);

        AudioManager.Instance.SetVolume(channel, sliderValue);

        soundLevelsText.text = sliderValue + " / " +"100";
    }   
}
