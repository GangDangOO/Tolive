using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour
{
    static public DB instance;
    private void Awake() {
        if(instance != null) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    //1,씬 이동
    //2,세이브와 로드
    //3,미리 만들어두면 편하다 (아이템)

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;
}
