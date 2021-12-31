using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    public int health = 20;
    public GameObject WoodEffect;
    DropItem ThisItem;
    // Start is called before the first frame update
    void Start()
    {
        ThisItem = transform.GetComponent<DropItem>();
        WoodEffect.SetActive(false);
    }

    IEnumerator Tree() {
        WoodEffect.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        WoodEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Axe"){
            StartCoroutine(Tree());
            health -= 5;
            if(health <= 0) {
                ThisItem.Drop();
                gameObject.SetActive(false);
            }
        }
    }
}
