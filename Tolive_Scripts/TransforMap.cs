using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransforMap : MonoBehaviour
{
    Setting Save;
    GameObject Player;
    //FindObjectOfType<> -> 하이어라키에 있는 모든 객체의 <>컴포넌트를 검색해서 리턴 (다수의 객체)
    //GetComponent<> -> 해당스크립트가 적용된 객체의 <>컴포넌트를 검색해서 리턴 (단일 객체)
    //검색 범위차이

    private void Start()
    {
        Save = GameObject.Find("Settings").GetComponent<Setting>();
        Player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            if(Setting.potalCool == true)
            {
                StartCoroutine(Save.Saving());
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        LoadingScene.LoadScene("Cave");
    }
}
