using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    GameObject player;
    GameObject a;
    GameObject S;
    GameObject B;
    int i = 10;


    void Awake() {
        a = GameObject.Find("Arrow");
        player = GameObject.Find("Player");
        S = GameObject.Find("SP");
        B = GameObject.Find("Attack");
    }

    private void Start() {
        a.SetActive(false);
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            a.SetActive(true);
            a.transform.position = S.transform.position;
            a.GetComponent<Rigidbody>().AddForce(player.transform.forward * i, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Arrow")
            a.SetActive(false);
    }
}
