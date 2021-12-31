using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public GameObject Rock;
    public int CountRock;
    Vector3 Pos;

    private void Awake()
    {
        for(int i=0; i< CountRock; i++)
        {
            Pos = new Vector3(Random.Range(0.0f, 2500.0f), 0, Random.Range(0.0f, 2500.0f));
            Pos.y = Terrain.activeTerrain.SampleHeight(Pos);
            if (Pos.y > 70)
            {
                Instantiate(Rock, Pos, Quaternion.identity);
            }
            else i--;
        }
    }
}
