using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{
    public Light Sun;
    float time = 0;
    bool Morning = true;
    private void Awake()
    {
        Sun.GetComponent<Light>();
    }

    private void Update()
    {
        timeSun();
    }

    void timeSun()
    {
        if (Morning)
        {
            time -= (Time.deltaTime * 0.03f);
            Sun.intensity = time;
            if(time < 0)
            {
                Morning = false;
            }
        } else if (!Morning)
        {
            time += (Time.deltaTime * 0.1f);
            Sun.intensity = time;
            if(time > 1)
            {
                Morning = true;
            }
        }
    }
}
