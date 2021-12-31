using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        Player.GetComponent<Transform>();
    }

    private void Start()
    {
        Player.transform.position = gameObject.transform.position;
    }
}
