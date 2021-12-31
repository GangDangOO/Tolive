using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    public int health = 20;
    public GameObject RockEffect;
    DropItem ThisItem;
    // Start is called before the first frame update
    void Start() {
        ThisItem = transform.GetComponent<DropItem>();
        RockEffect.SetActive(false);
    }

    IEnumerator Rock() {
        RockEffect.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        RockEffect.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Pickax") {
            StartCoroutine(Rock());
            health -= 5;
            if (health <= 0) {
                ThisItem.Drop();
                gameObject.SetActive(false);
            }
        }
    }
}
