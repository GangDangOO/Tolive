using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class TestMove : MonoBehaviour
{
    public RectTransform moveStick;
    RectTransform moveOne;
    public FixedJoystick MoveJoystick;
    //public FixedButton JumpButton;
    public FixedTouchField TouchField;
    public GameObject[] Prefab;
    GameObject[] Weapon;
    [HideInInspector]
    public int m_Attack;
    float attacktime = 3f;
    int i;
    int m_WALK = 2;
    Animator anim;
    Equipment Equ;
    bool Aj = false;
    public Transform bullet;
    public Transform bullet2;
    GameObject spPoint;
    GameObject RockOn;
    Inventory inven;
    Coroutine ATKco;
    Stat stat;

    [HideInInspector] public AudioSource AttackAudio;
    [Header("AttackSound")]
    public AudioClip[] AttackSound;

    BoxCollider A;
    public BoxCollider[] WeaponCol;
    // Start is called before the first frame update
    private void Awake() {
        spPoint = GameObject.Find("BowPoint");
        Weapon = new GameObject[Prefab.Length];
        RockOn = GameObject.Find("BowRockOn");
        AttackAudio = transform.GetComponent<AudioSource>();
    }
    void Start()
    {
        stat = GetComponent<Stat>();
        moveOne = GameObject.Find("Fixed Joystick").GetComponent<RectTransform>();
        Equ = GameObject.FindObjectOfType<Equipment>();
        anim = GetComponent<Animator>();
        m_Attack = 3;
        //anim.SetInteger("WALK", m_WALK);
        for(int i=0; i<Prefab.Length; i++) {
            Weapon[i] = Prefab[i];
            Weapon[i].SetActive(false);
        }
        for (int i = 0; i < WeaponCol.Length; i++) {
            WeaponCol[i].enabled = false;
        }
        RockOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        attacktime -= Time.deltaTime;
        var fps = GetComponent<RigidbodyFirstPersonController>();
        Vector2 v = Vector2.ClampMagnitude(new Vector2(fps.RunAxis.x, fps.RunAxis.y), 1f);
        float MoveHandler34 = v.magnitude;

        if (Application.platform == RuntimePlatform.Android) {
            fps.RunAxis = MoveJoystick.inputVector;
            //fps.JumpAxis = JumpButton.Pressed;
        }
        else {
            fps.RunAxis.x = Input.GetAxis("Horizontal");
            fps.RunAxis.y = Input.GetAxis("Vertical");
            Vector2 A = new Vector2(0.5f + fps.RunAxis.x / 4.5f, 0.5f + fps.RunAxis.y / 4.5f);
            Vector2 B = new Vector2(
                ((A.x * moveOne.sizeDelta.x) - (moveOne.sizeDelta.x * 0.5f)),
                ((A.y * moveOne.sizeDelta.y) - (moveOne.sizeDelta.y * 0.5f)));
            moveStick.anchoredPosition = B;

        }
        fps.mouseLook.LookAxis = TouchField.TouchDist;
       
        if(Aj == false) {
            if(MoveHandler34 >0.9 && fps.RunAxis.y > 0) {
                anim.SetInteger("WALK", 2);
            }
            else if(MoveHandler34 == 0) {
                anim.SetInteger("WALK", 0);
            }
            else if(MoveHandler34 > 0 && MoveHandler34 < 1){
                anim.SetInteger("WALK", 1);
            }
        }
    }
    public void TheAttack() {
        if (attacktime > 0)
            return;
        //anim.SetInteger("WALK", 1); //walk
        //anim.SetInteger("WALK", 2); //run
        if (Aj == false) {
            for (int i = 0; i < Weapon.Length; i++) {
                if (Weapon[i].activeSelf == true) {
                    if (Weapon[i].tag == "TwoHand") {
                        anim.SetInteger("WALK", m_Attack);
                        ATKco = StartCoroutine(ColAtive());
                        AttackAudio.clip = AttackSound[0];
                        AttackAudio.Play();
                        if (Equ.equipItemList[0].itemDuration == 0) {
                            GameObject.FindWithTag("TwoHand").SetActive(false);
                            stat.PlayerATK = 5;
                            Inventory.w = 0;
                        }
                    }
                    if (Weapon[i].tag == "Spear") {
                        anim.SetInteger("WALK", m_Attack);
                        ATKco = StartCoroutine(ColAtive());
                        AttackAudio.clip = AttackSound[0];
                        AttackAudio.Play();
                        if (Equ.equipItemList[0].itemDuration == 0) {
                            GameObject.FindWithTag("TwoHand").SetActive(false);
                            stat.PlayerATK = 5;
                            Inventory.w = 0;
                        }
                    }
                    if (Weapon[i].tag == "Knife") {
                        anim.SetInteger("WALK", m_Attack);
                        ATKco = StartCoroutine(ColAtive());
                        AttackAudio.clip = AttackSound[1];
                        AttackAudio.Play();
                        if (Equ.equipItemList[0].itemDuration == 0) {
                            GameObject.FindWithTag("TwoHand").SetActive(false);
                            stat.PlayerATK = 5;
                            Inventory.w = 0;
                        }
                    }
                    if (Weapon[i].tag == "Bow") {
                        if (Weapon[i].name == "Bow") {
                            RockOn.SetActive(true);
                            for (int j = 0; j < Inventory.inventoryItemList.Count; j++) {
                                if (Inventory.inventoryItemList[j].itemID == 1007) {
                                    if(Inventory.inventoryItemList[j].itemCount >= 1) {
                                        Inventory.inventoryItemList[j].itemCount--;
                                        attacktime = 3f;
                                        StartCoroutine(WaitForIt());
                                    }
                                else if (Inventory.inventoryItemList[j].itemCount == 0) {
                                    Inventory.inventoryItemList.RemoveAt(j);
                                    GameObject Arrow = GameObject.Find("BowPoint");
                                    Arrow.SetActive(false);
                                }
                                }
                            }
                        } else if (Weapon[i].name == "Slingshot") {
                            RockOn.SetActive(true);
                            for (int j = 0; j < Inventory.inventoryItemList.Count; j++) {
                                if (Inventory.inventoryItemList[j].itemID == 1008) {
                                    if(Inventory.inventoryItemList[j].itemCount >= 1) {
                                        Inventory.inventoryItemList[j].itemCount--;
                                        attacktime = 3f;
                                        StartCoroutine(WaitForIt());
                                    }
                                else if (Inventory.inventoryItemList[j].itemCount == 0) {
                                    Inventory.inventoryItemList.RemoveAt(j);
                                    GameObject Arrow = GameObject.Find("BowPoint");
                                    Arrow.SetActive(false);
                                }
                                }
                            }
                        }
                    }
                    if (Equ.equipItemList[0].itemDuration == 0) {
                            Weapon[i].SetActive(false);
                            stat.PlayerATK = 5;
                            Inventory.w = 0;
                    }
                }
            }
        }
    }

    IEnumerator ColAtive() {
        A = Inventory.op.GetComponent<BoxCollider>();
        A.enabled = true;
        Aj = true;
        yield return new WaitForSeconds(1.2f);
        A.enabled = false;
        Aj = false;
    }
    IEnumerator WaitForIt() {

        yield return new WaitForSeconds(2.0f);
        float power = 50.0f;
        Vector3 relativePos = transform.forward.normalized * 10;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Transform myBullet = Instantiate(bullet, spPoint.transform.position, spPoint.transform.rotation) as Transform;
        myBullet.GetComponent<Rigidbody>().AddForce(spPoint.transform.forward * power, ForceMode.Impulse);
        AttackAudio.clip = AttackSound[2];
        AttackAudio.Play();
        yield return new WaitForSeconds(1.0f);
        RockOn.SetActive(false);
    }
    
}
