using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public static TreeSpawn instance;
    public GameObject[] Prefab;
    [HideInInspector] public static GameObject[] Tree;
    public int CountTree;
    Vector3 TreePos;

    private void Awake()
    {
        Tree = new GameObject[CountTree];
    }

    private void Start()
    {
        for(int i=0; i<CountTree; i++)
        {
            TreePos = new Vector3(Random.Range(0.0f, 2500.0f), 0, Random.Range(0.0f, 2500.0f));
            TreePos.y = Terrain.activeTerrain.SampleHeight(TreePos);
            int RdTree = Random.Range(0, Prefab.Length);
            if (TreePos.y > 60 )
            {
                Tree[i] = Instantiate(Prefab[RdTree], TreePos, Quaternion.identity) as GameObject;
            }
            else i--;
        }
    }
}
