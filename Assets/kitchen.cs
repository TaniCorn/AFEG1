using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchen : MonoBehaviour
{
    public AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Red()
    {
        audio.volume = 3.0f;
    }
    public void NotRed()
    {
        audio.volume = 1.0f;
    }
}
