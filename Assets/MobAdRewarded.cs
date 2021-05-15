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

    private bool shown = true;

    private const string rewardedUnitId = "ca-app-pub-9652722646808077/8928743776";

    private void Start()
    {
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
    }

    void Update()
    {
        if (shown == false)
        {
            ShowRewardedAd();
        }
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
        shown = false;
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            shown = true;
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        score++;
        PlayerPrefs.SetInt("coin", score);
        textScore.text = score.ToString();
    }
}
