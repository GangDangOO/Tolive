using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject Tri = other.gameObject;
        Tri.SetActive(false);
    }
}
