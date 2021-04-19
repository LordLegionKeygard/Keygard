using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlLink : MonoBehaviour
{
    public string Url;

    public void OpenLink()
    {
        Application.OpenURL(Url);
    }
}
