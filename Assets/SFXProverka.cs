using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXProverka : MonoBehaviour
{
    public AudioSource JumpSound;

    public void JumpHandler()
    {
        JumpSound.Play();
    }
}
