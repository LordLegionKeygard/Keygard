using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Newtonsoft.Json;
using System;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class Location : ScriptableObject
{
    private static Location _instance = null;
    public static Location Instance => _instance ?? Resources.Load<Location>("Locations");
    private const string KeyLevels = "Levels";
    private const string KeyCurrentLevelNumber = "CurrentLevelNumber";
    public int LevelsCount = 12;
    public int AvailableLevels = 12; //сейчас 12

    public int CurrentLevelNumber { get; set; }

    public List<bool> Levels { get; set; } = null;

    public void Load()
    {
        Debug.Log("<color=green>--- Load ---</color>");

        string json = PlayerPrefs.GetString(KeyLevels);
        Debug.Log(json);
        Levels = JsonConvert.DeserializeObject<List<bool>>(json);

        if (Levels == null || Levels != null && Levels.Count == 0)
        {
            Levels = new bool[LevelsCount].ToList();

            Levels[0] = true;
        }
        Debug.Log("Levels = " + Levels);

        CurrentLevelNumber = PlayerPrefs.GetInt(KeyCurrentLevelNumber, 1);
    }

    public void Save()
    {
        Debug.Log("<color=blue>--- Save ---</color>");
        string json = JsonConvert.SerializeObject(Levels);

        Debug.Log(json);

        PlayerPrefs.SetString(KeyLevels, json);

        PlayerPrefs.SetInt(KeyCurrentLevelNumber, CurrentLevelNumber);

        PlayerPrefs.Save();
    }

    public void CheckCurrentLevel()
    {
        Debug.Log("<color=yellow>--- CheckCurrentLevel ---</color>");

        int indexLastOpenedLevel = Levels.FindLastIndex(
        (bool levelIsOpened) =>
        {
            return levelIsOpened == true;
        });

        Debug.Log($"indexLastOpenedLevel = {indexLastOpenedLevel}");

        int numberLastOpenedLevel = indexLastOpenedLevel + 1;

        Debug.Log($"numberLastOpenedLevel = {numberLastOpenedLevel}");

        Debug.Log($"CurrentLevelNumber = {CurrentLevelNumber}");

        bool isLastOpenedLevel = numberLastOpenedLevel <= CurrentLevelNumber;

        Debug.Log($"isLastOpenedLevel = {isLastOpenedLevel}");

        int nextLevelIndex = indexLastOpenedLevel + 1;

        Debug.Log($"nextLevelIndex = {nextLevelIndex}");


        if (isLastOpenedLevel &&
            numberLastOpenedLevel < AvailableLevels &&
            CurrentLevelNumber == numberLastOpenedLevel + 1)
        {
            Levels[nextLevelIndex] = true;
        }
        else if(CurrentLevelNumber - 1 == AvailableLevels )
        {
            CurrentLevelNumber = 0;
        }

        Save();
    }
}
