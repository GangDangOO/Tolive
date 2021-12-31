using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTree : MonoBehaviour
{
    BoxCollider Col;
    RemoveTree Script;

    private void Awake()
    {
        Script = this.GetComponent<RemoveTree>();
        Col = this.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Destroy(Col);
        yield return new WaitForSeconds(1f);
        Destroy(Script);
    }
}
