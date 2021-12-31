using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;
    public int _count;

    private void OnTriggerStay(Collider other) {
        Debug.Log("아이템");
        if (Input.GetKeyDown(KeyCode.Z)) {
            Inventory.instance.GetAnItem(itemID, _count);
            Destroy(this.gameObject);
        }
    }
}
