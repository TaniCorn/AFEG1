using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chef : MonoBehaviour
{
    public bool inKitchen = false;
    float shouttime = 0.5f;
    public Sprite image1;
    public Sprite image2;
    bool flipflop = false;

    public List<AudioClip> audioClips = new List<AudioClip>();
    public AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Image>().enabled = false;

    }
    public void GoToSmokeBreak()
    {
        GetComponent<Image>().color = Color.white;
        inKitchen = false;
        GetComponent<Image>().enabled = false;
        int i = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[i]);
        FindObjectOfType<Fail>().DishFailed();
    }

    public void GoToKitchen()
    {
        inKitchen = true;
        GetComponent<Image>().enabled = true;
    }
    public void Update()
    {
        shouttime -= Time.deltaTime;
        if (shouttime < 0)
        {
            if (flipflop)
            {
                flipflop = false;
                GetComponent<Image>().sprite = image1;
            }
            else
            {
                flipflop=true;
                GetComponent<Image>().sprite = image2;
            }
        }
    }

    public void Angry()
    {
        GetComponent<Image>().color = Color.red;
        int i = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[i]);

    }
}
