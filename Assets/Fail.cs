using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fail : MonoBehaviour
{
    public List<GameObject> Fails = new List<GameObject>();
    int failed = 0;
    public GameObject fail;
    public GameObject success;
    public void DishFailed()
    {
        if(Fails.Count > 0)
        {
            Fails[0].GetComponent<Image>().color = Color.red;
            Fails.RemoveAt(0);
            failed++;
            Check();
        }

    }
    public void DishSucceded()
    {
        if (Fails.Count > 0)
        {
            Fails[0].GetComponent<Image>().color = Color.green;
            Fails.RemoveAt(0);
            Check();
        }
    }
    private void Check()
    {
        if(Fails.Count == 0)
        {
            if (failed >= 5)
            {
                fail.SetActive(true);
            }
            else
            {
                success.SetActive(true);
            }
        }

    }
}
