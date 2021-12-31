using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;

public class Title : MonoBehaviour
{
    public static bool CheckLoad;
    public static bool Tutorial;

    public void ClickStart() {
        CheckLoad = false;
        Tutorial = true;
        LoadingScene.LoadScene("Scene 1");
    }
    public void ClickLoad() {
        CheckLoad = true;
        Tutorial = false;
        LoadingScene.LoadScene("Scene 1");
    }
    public void ClickExit() {
        Debug.Log("Exit");
    }
}
