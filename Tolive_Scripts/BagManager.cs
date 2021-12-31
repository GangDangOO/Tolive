using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public GameObject go;

    private void Awake() {
        go.SetActive(false);
    }

    public void OnClickBag() {
        if (go.activeSelf == false) {
            go.SetActive(true);

        }
        else if (go.activeSelf == true) {
            go.SetActive(false);
        }

    }
}
