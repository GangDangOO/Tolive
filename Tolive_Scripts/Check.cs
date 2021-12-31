using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public static Check instance;

    public GameObject[] Objects;

    public void Visible()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].SetActive(false);
        }
    }
}
