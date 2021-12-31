using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTerrian : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mySize = GameObject.Find("Terrain").GetComponent<Terrain>().terrainData.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
