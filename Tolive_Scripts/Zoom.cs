using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour {

    
    public GameObject firstPersonCamera; //Zoom될때 카메라
    public GameObject overheadCamera; ////MainCamera
    public GameObject CaveCamera;
    bool setItem = false;
    private float Transform;
    Inventory asdff;
    GameObject RockOn;
    GameObject RockOn2;
    FixedJoystick JoyStick;
    GameObject Player;
    GameObject playerAngle;
    private float x;
    private float y;
    private float z;
    static Quaternion q;

    public void Awake() {
        firstPersonCamera = GameObject.FindGameObjectWithTag("Zoom");
        overheadCamera = GameObject.FindGameObjectWithTag("MainCamera");
        CaveCamera = GameObject.FindGameObjectWithTag("CaveCamera");
        asdff = FindObjectOfType<Inventory>();
        RockOn = GameObject.Find("BowRockOn");
        RockOn2 = GameObject.Find("SlingRockOn");
        JoyStick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        Player = GameObject.Find("Idle");
        
    }
    public void Start() {
        firstPersonCamera.SetActive(false);
        overheadCamera.SetActive(true);
        RockOn.SetActive(false);
        RockOn2.SetActive(false);
        JoyStick.enabled = true;
        
    }

    public void OnClickBag(Button B) {
        if (Inventory.op.name == "Bow") {
            if (setItem == false) {
                overheadCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
                RockOn.SetActive(true);
                JoyStick.enabled = false;
                setItem = true;
                q = Player.transform.rotation;
            } else if (setItem == true) {
                overheadCamera.SetActive(true);
                firstPersonCamera.SetActive(false);
                RockOn.SetActive(false);
                setItem = false;
                JoyStick.enabled = true;
                Player.transform.rotation = q;
            }
        }
        if (Inventory.op.name == "Slingshot") {
            if (setItem == false) {
                overheadCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
                RockOn2.SetActive(true);
                setItem = true;
                JoyStick.enabled = false;
            } else if (setItem == true) {
                overheadCamera.SetActive(true);
                firstPersonCamera.SetActive(false);
                RockOn2.SetActive(false);
                setItem = false;
                JoyStick.enabled = true;
            }
        }
    }
}
