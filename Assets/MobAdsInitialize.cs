using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdsInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
