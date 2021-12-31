using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour {

    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }


    public void BowAttack() {
        if (tag == "Bow") {
            anim.SetTrigger("BowAttack");
        }
    }
    public void SpearAttack() {
        if (tag == "Spear") {
            anim.SetTrigger("SpearAttack");
        }
    }
    public void KnifeAttack() {
        if (tag == "Knife") {
            anim.SetTrigger("KnifeAttack");
        }
    }
    public void TwoHandAttack() {
        if (tag == "TwoHand") {
            anim.SetTrigger("TwoHandAttack");
        }
    }

}
