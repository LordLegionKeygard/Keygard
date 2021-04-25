using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonateCanvas : MonoBehaviour
{
    public GameObject _donateBackground;
    public GameObject _allButtons;
    public GameObject _gameLogo;

    public void BackHandler()
    {
        _donateBackground.SetActive(false);
        _allButtons.SetActive(true);
        _gameLogo.SetActive(true);
    }

    public void BuyCoinsHandler()
    {

    }

    public void RemoveAd()
    {
        
    }
}
