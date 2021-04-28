using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCanvas : MonoBehaviour
{
    public int LevelPerLocation = 4;
    public GameObject _allButtons;
    public GameObject _locationSelectionPanel;
    public GameObject _locationSelectionImage;
    public GameObject _gameLogo;

    public Location Location;

    [Header("Levels")]
    public GameObject _crystalLevels;
    public GameObject _labyrinthLevels;
    public GameObject _treganLevels;
    public GameObject _littiritteLevels;
    public GameObject _ivoryLevels;
    public GameObject _blackwalLevels;

    public void BackHandler()
    {
        _locationSelectionPanel.SetActive(false);
        _allButtons.SetActive(true); 
        _gameLogo.SetActive(true);      
    }

    public void CrystalCaveHandler()
    {
        _crystalLevels.SetActive(true);
        _locationSelectionImage.SetActive(false);
    }

    public void LabyrinthHandler()
    {
        _labyrinthLevels.SetActive(true);
        _locationSelectionImage.SetActive(false);      
    }

    public void TreganHandler()
    {
        _treganLevels.SetActive(true);
        _locationSelectionImage.SetActive(false);
    }

    public void LittiritteHandler()
    {
        _littiritteLevels.SetActive(true);
        _locationSelectionImage.SetActive(false);     
    }

    public void IvoryHandler()
    {
        _ivoryLevels.SetActive(true); 
        _locationSelectionImage.SetActive(false);      
    }
    
    

    public void BlackWallHandler()
    {
        _blackwalLevels.SetActive(true);
        _locationSelectionImage.SetActive(false);      
    }

    private void Awake()
    {
        Location.Load();

        LevelSelection[] levels = GetComponentsInChildren<LevelSelection>(true);

        var locationViews = GetComponentsInChildren<LocationView>(true);

        for (int levelIndex = 0; levelIndex < Location.AvailableLevels; levelIndex++)
        {
            levels[levelIndex].Button.interactable = Location.Levels[levelIndex];

            int levelNumber = levelIndex + 1;

            int locationsSubLevel = levelNumber % LevelPerLocation;/// %  это остаток от деления levelNumber на LevelPerLocation, например 15 % 4 = 3 
            
            if (locationsSubLevel == 1)
            {
                int LocationIndex = levelIndex / LevelPerLocation;

                if(LocationIndex != locationViews.Length)
                {
                    locationViews[LocationIndex].Button.interactable = Location.Levels[levelIndex];
                }
            }
        }
    }
}
