using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;


public class MobAdRewarded2 : MonoBehaviour
{
    private RewardBasedVideoAd adReward;

    private string idApp, idReward;

    [SerializeField] Button BtnReward;
    [SerializeField] private Text textScore;
    private int score;


    void Start()
    {
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
        idReward = "ca-app-pub-9652722646808077/8928743776";

        adReward = RewardBasedVideoAd.Instance;
    }


    #region Reward video methods ---------------------------------------------

    public void RequestRewardAd()
    {
        AdRequest request = AdRequestBuild();
        adReward.LoadAd(request, idReward);

        adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded += this.HandleOnAdRewarded;
        adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
    }

    public void ShowRewardAd()
    {
        if (adReward.IsLoaded())
            adReward.Show();
    }
    //events
    public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
    {//ad loaded
        ShowRewardAd();
    }

    public void HandleOnAdRewarded(object sender, EventArgs args)
    {//user finished watching ad
        score++;
        PlayerPrefs.SetInt("coin", score);
        textScore.text = score.ToString();
    }

    public void HandleOnRewardedAdClosed(object sender, EventArgs args)
    {//ad closed (even if not finished watching)
        BtnReward.interactable = true;

        adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded -= this.HandleOnAdRewarded;
        adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

    #endregion

    //other functions
    //btn (more points) clicked
    public void OnGetMorePointsClicked()
    {
        BtnReward.interactable = false;
        RequestRewardAd();
    }

    //------------------------------------------------------------------------
    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }

    void OnDestroy()
    {
        adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
        adReward.OnAdRewarded -= this.HandleOnAdRewarded;
        adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
    }

}
