using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPoint : MonoBehaviour
{
    GameObject Animal;

    Vector3 ThisPoint;

    private void Start()
    {
        ThisPoint = gameObject.transform.position;
        ThisPoint.y = Terrain.activeTerrain.SampleHeight(gameObject.transform.position) + 3;
        Animal = Instantiate(Animal, ThisPoint, Quaternion.identity) as GameObject;
        Animal.SetActive(false);
    }

    public void Prefab(GameObject _Bear)
    {
        Animal = _Bear;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Animal.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animal.SetActive(false);
        }
    }
}
