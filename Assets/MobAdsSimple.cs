using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdsSimple : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private bool shown = true;

    private const string interstitialUnitId = "ca-app-pub-3940256099942544/8691691433";

    void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    void Update()
    {
        if (shown == false)
        {
            ShowAd();
            Debug.Log("Not yet...");
        }
    }
    public void ShowAd()
    {
        shown = false;
        if (interstitialAd.IsLoaded())
        {
            if (PlayerPrefs.HasKey("ads") == false)
            {
                interstitialAd.Show();
                shown = true;
            }
        }
    }
}
