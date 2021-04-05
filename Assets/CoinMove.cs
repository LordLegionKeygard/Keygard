using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private Text textScore;

    void Update()
    {
        if (textScore.text == ("26"))
        {
            transform.position = new Vector3 (1706f, 1040f, 0f);
        }
    }
}
