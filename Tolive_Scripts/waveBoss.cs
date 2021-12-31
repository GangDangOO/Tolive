using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveBoss : MonoBehaviour
{
    GameObject Cube2;
    private void Start()
    {
        Cube2 = GameObject.Find("Point2");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = Cube2.transform.position;
        }
    }
}
