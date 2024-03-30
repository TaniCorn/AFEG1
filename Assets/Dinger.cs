using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinger : MonoBehaviour
{
    private void OnMouseDown()
    {
        FindObjectOfType<Plate>().Ding();
    }
}
