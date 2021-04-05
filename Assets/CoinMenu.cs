using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMenu : MonoBehaviour
{
    private int score;
    [SerializeField] private Text textScore;

    private void Start()
    {
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
    }
}
