using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;         // 움직이는 스피드.
    public float AttackGap;     // 총알이 발사되는 간격.

    private Transform Vec;      // 카메라 벡터.
    private Vector3 MovePos;    // 플레이어 움직임에 대한 변수.

    private bool ContinuouFire; // 게속 발사할 것인가? 에 대한 플래그.

    Attack atk;

    void Init() {
        //공개.
        AttackGap = 0.2f;

        // 비공개
        MovePos = Vector3.zero;
        ContinuouFire = true;
    }

    void Start() {
        Vec = GameObject.Find("CameraVector").transform;

        Init();
    }

    void Update() {
        //KeyCheck();
    }
    
    // 총알 키 체크.
    /*public void KeyCheck() {
        if (Input.GetButtonDown("Jump"))
            StartCoroutine("NextFire");
        else if (Input.GetButtonUp("Jump"))
            ContinuouFire = false;
    }*/

    // 연속발사.
    IEnumerator NextFire() {
        ContinuouFire = true;
        while (ContinuouFire) {
            // 총알을 리스트에서 가져온다.
            BulletInfoSetting(ObjManager.Call().GetObject("Arrow"));
            yield return new WaitForSeconds(AttackGap); // 시간지연.
        }
    }

    // 총알정보 셋팅.
    void BulletInfoSetting(GameObject _Bullet) {
        if (_Bullet == null) return;

        _Bullet.transform.position = transform.position;                // 총알의 위치 설정
        _Bullet.transform.rotation = transform.rotation;                // 총알의 회전 설정.
        _Bullet.SetActive(true);                                        // 총알을 활성화 시킨다.
        _Bullet.GetComponent<Arrow>().StartCoroutine("MoveArrow");    // 총알을 움직이게 한다.
    }
}