using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvent : MonoBehaviour
{
    bool first = false;
    public GameObject mainCam;
    public GameObject EventCam;
    Animator Anim;

    void Start() {
        EventCam.SetActive(false);
        Anim = GameObject.Find("Boss_Bear2").GetComponent<Animator>();
        Anim.SetInteger("AnimalState", 3);
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            if(first == false) {
                StartCoroutine(BossEvent_Co(4f));
            }
        }
        first = true;
    }
    IEnumerator BossEvent_Co(float time) {
        mainCam.SetActive(false);
        EventCam.SetActive(true);
        yield return new WaitForSeconds(time);
        EventCam.SetActive(false);
        mainCam.SetActive(true);
    }
}
