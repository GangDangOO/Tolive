using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject[] Prefab;
    GameObject[] Weapon;
    Animator anim;
    public Transform bullet;
    public Transform bullet2;
    float timer = 2f;
    Collider coll;
    int j;
    float attacktime = 3f;
    BoxCollider WeaponColl;
    GameObject Arrowshot;
    GameObject spPoint;
    GameObject spPoint2;
    GameObject OneCamera;
    public float AttackGap;
    private Vector3 MovePos;
    private bool ContinuouFire;
    Equipment Equ;
    Stat stat;


    [HideInInspector] public AudioSource AttackAudio;
    [Header("AttackSound")]
    public AudioClip[] AttackSound;

    BoxCollider A;
    private void Awake() {
        stat = GameManeger.FindObjectOfType<Stat>();
        Equ = GameObject.FindObjectOfType<Equipment>();
        Weapon = new GameObject[Prefab.Length];
        //Arrowshot = GameObject.Find("Arrow");
        spPoint = GameObject.Find("BowPoint");
        spPoint2 = GameObject.Find("SlingPoint");
        OneCamera = GameObject.Find("Camera2");
        AttackAudio = transform.GetComponent<AudioSource>();
    }

    void Start() {
        anim = GetComponent<Animator>();
        for (int i = 0; i < Prefab.Length; i++) {
            Weapon[i] = Prefab[i];
        }
    }

    void Update() {
        attacktime -= Time.deltaTime;
    }


    public void theAttack() {
        if (attacktime > 0)
            return;

        for (int i = 0; i < Weapon.Length; i++) {
            if (Weapon[i].activeSelf == true) {
                if (Weapon[i].tag == "Spear") {
                    anim.SetInteger("Weapon", 1);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name =="Spear") {
                        GameObject.FindWithTag("Spear").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
               if (Weapon[i].tag == "Spear")
                {
                    anim.SetInteger("Weapon", 1);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "S_Spear")
                    {
                        GameObject.FindWithTag("Spear").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                //AttackAudio.Stop();
                if (Weapon[i].tag == "Knife") {
                    anim.SetInteger("Weapon", 2);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[1];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name =="Knife") {
                        GameObject.FindWithTag("Knife").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                if (Weapon[i].tag == "Knife")
                {
                    anim.SetInteger("Weapon", 2);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[1];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "S_Knife")
                    {
                        GameObject.FindWithTag("Knife").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                //AttackAudio.Stop();
                if (Weapon[i].tag == "TwoHand") {
                    anim.SetInteger("Weapon", 3);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "Axe") {
                        GameObject.FindWithTag("TwoHand").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                if (Weapon[i].tag == "TwoHand")
                {
                    anim.SetInteger("Weapon", 3);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "Pickax")
                    {
                        GameObject.FindWithTag("TwoHand").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                if (Weapon[i].tag == "TwoHand")
                {
                    anim.SetInteger("Weapon", 3);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "Stick")
                    {
                        GameObject.FindWithTag("TwoHand").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                if (Weapon[i].tag == "TwoHand")
                {
                    anim.SetInteger("Weapon", 3);
                    StartCoroutine(ColAtive());
                    AttackAudio.clip = AttackSound[0];
                    AttackAudio.Play();
                    if (Equ.equipItemList[0].itemDuration <= 0 && Weapon[i].name == "Torch")
                    {
                        GameObject.FindWithTag("TwoHand").SetActive(false);
                        print("부서짐");
                    }
                    break;
                }
                //AttackAudio.Stop();
                if (Weapon[i].tag == "Bow") {
                        if (Weapon[i].name == "Bow") {
                            for (j = 0; j < Inventory.inventoryItemList.Count; j++) {
                                if (Inventory.inventoryItemList[j].itemID == 1007) {
                                    if (Inventory.inventoryItemList[j].itemCount >= 1){
                                        Inventory.inventoryItemList[j].itemCount--;
                                        anim.SetInteger("Weapon", 4);
                                        attacktime = 3f;
                                        StartCoroutine(WaitForIt());
                                } else if (Inventory.inventoryItemList[j].itemCount == 0) {
                                        print("화살 부족");
                                        Inventory.inventoryItemList.RemoveAt(j);
                                        GameObject Arrow = GameObject.Find("BowPoint");
                                        Arrow.SetActive(false);
                                }
                            }
                        }
                        //AttackAudio.Stop();
                    }
                if (Weapon[i].name == "Slingshot") {
                    for(j = 0; j < Inventory.inventoryItemList.Count; j++) {
                        if (Inventory.inventoryItemList[j].itemID == 1008) {
                            if (Inventory.inventoryItemList[j].itemCount >= 1) {
                                anim.SetInteger("Weapon", 4);
                                Inventory.inventoryItemList[j].itemCount--;
                                attacktime = 3f;
                                StartCoroutine(WaitForIt2());
                            } else if (Inventory.inventoryItemList[j].itemCount == 0) {
                                print("짱돌 부족");
                                Inventory.inventoryItemList.RemoveAt(j);
                                GameObject SlingRock = GameObject.Find("SlingPoint");
                                SlingRock.SetActive(false);
                            }
                        }
                    }
                    //AttackAudio.Stop();
                }
                    if (Equ.equipItemList[0].itemDuration <= 0) {
                        GameObject.FindWithTag("Bow").SetActive(false);
                        print("부서짐");
                    }
                }
            } else {
                anim.SetTrigger("Attack");
            }
        }
    }
    IEnumerator WaitForIt() {
        yield return new WaitForSeconds(2.0f);
        float power = 50.0f;
        Vector3 relativePos = transform.forward.normalized * 10;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Transform myBullet = Instantiate(bullet, spPoint.transform.position, rotation) as Transform;
        myBullet.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
        AttackAudio.clip = AttackSound[2];
        AttackAudio.Play();
    }
    IEnumerator WaitForIt2() {
        yield return new WaitForSeconds(2.0f);
        float power2 = 50.0f;
        Vector3 relativePos = transform.forward.normalized * 10;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Transform myBullet2 = Instantiate(bullet2, spPoint2.transform.position, rotation) as Transform;
        myBullet2.GetComponent<Rigidbody>().AddForce(spPoint2.transform.forward * power2, ForceMode.Impulse);
        AttackAudio.clip = AttackSound[2];
        AttackAudio.Play();
    }
    
    IEnumerator ColAtive() {
        A = Inventory.op.GetComponent<BoxCollider>();
        A.enabled = true;
        print(Equ.equipItemList[0].itemDuration);
        yield return new WaitForSeconds(0.5f);
        A.enabled = false;
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "AnimalA" ||
            other.gameObject.tag == "AnimalB" ||
            other.gameObject.tag == "AnimalC" ||
            other.gameObject.tag == "TreeRock")
        {
            Equ.equipItemList[0].itemDuration -= 5;
            if(Equ.equipItemList[0].itemDuration <= 0)
            {
                Inventory.op.SetActive(false);
                Equ.equipItemList[0] = new Item(0, "", "", Item.ItemType.Equip);
                stat.PlayerATK = 5;
                Inventory.w = 0;
            }
        }
    }
}