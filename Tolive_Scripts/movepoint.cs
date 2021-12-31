using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepoint : MonoBehaviour
{
    GameObject Cube;
    private void Start()
    {
        Cube = GameObject.Find("Point3");

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = Cube.transform.position;
        }
    }
}
