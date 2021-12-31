using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    public static GroundSpawn instance;

    public GameObject[] Prefab;
    [HideInInspector] public GameObject[] ThisAnimals;
    Rigidbody[] AnimalRB;
    BoxCollider[] AnimalCol;
    public int Count;
    Transform Player;

    private void Awake()
    {
        GroundSpawn.instance = this;
        Player = GameObject.FindWithTag("Player").transform;
        ThisAnimals = new GameObject[Count];
        AnimalCol = new BoxCollider[Count];
        AnimalRB = new Rigidbody[Count];
    }

    private void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            int Rd = Random.Range(0, Prefab.Length);
            ThisAnimals[i] = Instantiate(Prefab[Rd], Player.position, Quaternion.identity) as GameObject;
            AnimalCol[i] = ThisAnimals[i].GetComponent<BoxCollider>();
            AnimalRB[i] = ThisAnimals[i].GetComponent<Rigidbody>();
            ThisAnimals[i].SetActive(false);
        }
        StartCoroutine(TransPoint(1.0f));
    }

    IEnumerator TransPoint(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            for (int i = 0; i < Count; i++)
            {
                if (ThisAnimals[i].activeSelf == true)
                {
                    if (Vector3.Distance(ThisAnimals[i].transform.position, Player.position) > 100)
                    {
                        ThisAnimals[i].SetActive(false);
                    }
                }
                else if (ThisAnimals[i].activeSelf == false)
                {
                    Vector3 NewPos = Player.position + Player.forward * 60;
                    NewPos.x += Random.Range(-50, 50);
                    NewPos.y = Terrain.activeTerrain.SampleHeight(NewPos) + 1;
                    if(NewPos.y < 50)
                    {
                        i--;
                        continue;
                    }
                    ThisAnimals[i].transform.position = NewPos;
                    ThisAnimals[i].SetActive(true);
                    AnimalCol[i].enabled = true;
                    AnimalRB[i].useGravity = true;
                    ThisAnimals[i].GetComponent<Animals>().isDead = false;
                }
            }
        }
    }
}
