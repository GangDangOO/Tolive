using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    // 하위 오브젝트 스크립트
    AnimalPoint[] Point;
    // 몬스터 프리팹
    public GameObject prefabData;

    private void Awake()
    {
        Point = gameObject.GetComponentsInChildren<AnimalPoint>();
        for (int i = 0; i < Point.Length; i++)
        {
            Point[i].Prefab(prefabData);
        }
    }
}
