using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MobAdRewarded : MonoBehaviour
{
    private RewardedAd rewardedAd;
    [SerializeField] private Text textScore;
    private int score;

    private const string rewardedUnitId = "ca-app-pub-3940256099942544/5224354917";

    private void Start()
    {
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
    }
    void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);

        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    void OnDisable()
    {
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        score++;
        PlayerPrefs.SetInt("coin", score);
        textScore.text = score.ToString();
    }
}
