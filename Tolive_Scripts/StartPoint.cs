using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StartPoint : MonoBehaviour
{

    public string startPoint; //맵의 이동, 플레이어가 시작될 위치
    //private ThirdPersonInput thePlayer;
    private RigidbodyFirstPersonController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<RigidbodyFirstPersonController>();
     
        if (startPoint == thePlayer.currentMapName) {
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
