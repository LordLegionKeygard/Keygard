using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyIceStaff : MonoBehaviour
{
    [SerializeField] private Text textScore;
    
    private int score;
    public GameObject priceice;
    public GameObject buybtn;
    public GameObject equip;

    [SerializeField] int needscore;

    private void Start()
    {
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
    }

    public void BuyIceStaffHandler()
    {
        if(score >= needscore)
        {
            score-=5;
            PlayerPrefs.SetInt("coin", score);
            textScore.text = score.ToString();

            priceice.SetActive(false);
            buybtn.SetActive(false);
            equip.SetActive(true);            
        }
    }
}
