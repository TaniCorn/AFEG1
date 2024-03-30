using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChefTimer : MonoBehaviour
{
    public float timerTime = 5.0f;
    private bool smokeTime = true;
    private float time = 5.0f;
    private Image image;
    public Image childimage;
    public RectTransform clockHandle;
    private AudioSource audioSource;
    bool on = false;
    private void Start()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        on = false;
        image.enabled = false;
        childimage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (on)
        {
            clockHandle.SetPositionAndRotation(clockHandle.position, Quaternion.Euler(0, 0, 360 * time / timerTime));
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        if (time < 0)
        {
            if (smokeTime)
            {
                TurnOn();
                FindObjectOfType<Chef>().GoToKitchen();
                smokeTime = false;
            }
            else
            {
                audioSource.Stop();
                TurnOff();
                FindObjectOfType<Chef>().GoToSmokeBreak();
                RandomChefTime();
                smokeTime = true;
            }
        }

    }
    private void RandomChefTime()
    {
        float waitTime = Random.Range(10, 20);
        time = waitTime;
    }
    private void TurnOff()
    {
        on = false;
        image.enabled = false;
        childimage.enabled = false;
        FindObjectOfType<Red>().StopRed();
        FindObjectOfType<kitchen>().NotRed();
    }
    public void TurnOn()
    {
        on = true;
        time = timerTime;
        image.enabled = true;
        childimage.enabled = true;
        clockHandle.rotation = Quaternion.identity;
        FindObjectOfType<Red>().StartRed();
        FindObjectOfType<kitchen>().Red();
    }
}
