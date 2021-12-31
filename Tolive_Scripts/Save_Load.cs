using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;

public class Save_Load : MonoBehaviour
{
    GameObject Player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 이동해도 오브젝트 안사라짐
    }

    private void Start()
    {
        Invoke("getPlayer", 1.0f);
    }
    
    private void getPlayer()
    {
        Player = GameObject.FindWithTag("Player"); // 플레이어 위치
        print(Player);
    }

    public void Save() // 플레이어 위치값, 현재 씬 저장
    {
        
    }

    public void Load() // 저장해둔 씬 로드 후 플레이어 위치보정
    {
        
    }
}
