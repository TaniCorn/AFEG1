using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Red : MonoBehaviour
{
    bool red;
    float timer = 1.0f;
    bool flipflop = false;
    float shakeTime = 0.2f;
    public void StartRed()
    {
        red = true;
        timer = 0.0f;
            Cursor.visible = false;
    }
    public void StopRed()
    {
        red = false;
        Image sprite = GetComponent<Image>();
        Color c = sprite.color;
        float alpha = 0;
        c.a = alpha;
        sprite.color = c;
            Cursor.visible = true;
            Camera.main.transform.position = new Vector3(0, 0, -10);
    }
    private void FixedUpdate()
    {
        if (red)
        {
            if(shakeTime < 0)
            {
                Vector3 startPosition = Camera.main.transform.position;
                float shakeX = UnityEngine.Random.Range(-1f, 1f) * 0.5f;
                float shakeY = UnityEngine.Random.Range(-1f, 1f) * 0.5f;

                Camera.main.transform.position = Vector3.Slerp(new Vector3(startPosition.x, startPosition.y, startPosition.z),
                    new Vector3(startPosition.x + shakeX, startPosition.y + shakeY, startPosition.z), 0.2f);
                shakeTime = 0.2f;
            }
            shakeTime -= Time.deltaTime;
        }

    }
    private void Update()
    {
        if (red)
        {

            if (flipflop)
            {
                timer += Time.deltaTime;
                Image sprite = GetComponent<Image>();
                Color c = sprite.color;
                float alpha = timer;
                c.a = alpha;
                sprite.color = c;
                if (timer > 0.8f)
                {
                    flipflop = false;
                }
            }
            else
            {
                timer -= Time.deltaTime;
                Image sprite = GetComponent<Image>();
                Color c = sprite.color;
                float alpha = timer;
                c.a = alpha;
                sprite.color = c;
                if (timer < 0.1f)
                {
                    flipflop = true;
                }
            }

        }
    }
}
