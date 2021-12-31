using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potal : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Box;

    private void Start()
    {
        Cube.SetActive(false);
        Box.SetActive(false);
    }

    public void ASD()
    {
        Cube.SetActive(true);
        Box.SetActive(true);
    }
}
