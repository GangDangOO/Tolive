using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "AnimalA") {
            Destroy(gameObject);
            print("적중"); 
        }
        if (other.gameObject.tag == "AnimalB") {
            Destroy(gameObject);
            print("적중");
        }
        if (other.gameObject.tag == "AnimalC") {
            Destroy(gameObject);
            print("적중");
        } else {
            Destroy(gameObject, 5f);
        }
    }
}