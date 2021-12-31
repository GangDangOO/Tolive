using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCamera : MonoBehaviour
{
    Transform obj = null;

    void Start()
    {
        obj = GameObject.Find("Boss_Bear2").transform;
    }

    void Update()
    {
        transform.RotateAround(obj.position, Vector3.up, 40 * Time.deltaTime);
        transform.LookAt(obj);
    }
}
