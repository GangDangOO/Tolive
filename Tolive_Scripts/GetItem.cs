using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItem : MonoBehaviour
{
    GameObject Target;

    Coroutine DesText;
    bool Desbool = false;

    private Inventory IntoInventory;
    Text GetitemText;

    void Start() {
        IntoInventory = FindObjectOfType<Inventory>();
        
    }
    IEnumerator Des(string text) {
        if(Desbool == true) {
            StopCoroutine(DesText);
        }
        Desbool = true;
        GetitemText.text = text;
        yield return new WaitForSeconds(1.5f);
        GetitemText.text = "";
        Desbool = false;
    }
    private void Awake() {
        GetitemText = GameObject.Find("GetItemText").GetComponent<Text>();
        Target = null;
        GetitemText.text = "";
    }
    void Update()
    {
        if (Input.GetButtonUp("Fire2")) {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {// 1001 A
                if (hit.transform.name == "Apple(Clone)") {
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDA;
                    int j = Iteminfo.ItemCountA;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("사과를 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Banana(Clone)") {//3013 B
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDB;
                    int j = Iteminfo.ItemCountB;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("바나나를 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "HardLeather(Clone)") {//3011 C
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDC;
                    int j = Iteminfo.ItemCountC;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("단단한 가죽을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Leafs(Clone)") { //3006 D
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDD;
                    int j = Iteminfo.ItemCountD;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("잎을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Posion(Clone)") { //3008 E
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDE;
                    int j = Iteminfo.ItemCountE;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("독을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "RockItem(Clone)") { //3001 F
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDF;
                    int j = Iteminfo.ItemCountF;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("돌을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "SoftLeather(Clone)") { //3009 G
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDG;
                    int j = Iteminfo.ItemCountG;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("일반가죽을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Meat(Clone)") { //1003 H
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDH;
                    int j = Iteminfo.ItemCountH;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("고기를 흭득했습니다."));
                    Target.SetActive(false);

                }
                
                if (hit.transform.name == "Teeth(Clone)") { //3012 I
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDI;
                    int j = Iteminfo.ItemCountI;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("날카로운이빨을 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Wood(Clone)") { //3003 J
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDJ;
                    int j = Iteminfo.ItemCountJ;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("나무를 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Stem(Clone)") { //3004 K
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDK;
                    int j = Iteminfo.ItemCountK;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("줄기를 흭득했습니다."));
                    Target.SetActive(false);

                }
                if (hit.transform.name == "Leather(Clone)") { //3010 L
                    Target = hit.collider.gameObject;
                    int i = Iteminfo._itemIDL;
                    int j = Iteminfo.ItemCountL;
                    IntoInventory.GetAnItem(i, j);
                    DesText = StartCoroutine(Des("질긴가죽을 흭득했습니다."));
                    Target.SetActive(false);
                }
                if (hit.transform.name == "Box") { //3010 L
                    Target = hit.collider.gameObject;
                    Inventory.inventoryItemList.Add(new Item(20104, "단단한갑옷", "단단한 가죽으로 만든 갑옷", Item.ItemType.Equip));
                    Inventory.inventoryItemList.Add(new Item(20204, "단단한투구", "단단한 가죽으로 만든 투구", Item.ItemType.Equip));
                    Inventory.inventoryItemList.Add(new Item(20304, "단단한장갑", "단단한 가죽으로 만든 장갑", Item.ItemType.Equip));
                    Inventory.inventoryItemList.Add(new Item(20404, "단단한신발", "단단한 가죽으로 만든 신발", Item.ItemType.Equip));
                    Inventory.inventoryItemList.Add(new Item(1004, "독주머니", "전갈의 독을 사용할수 있게 해준다", Item.ItemType.Use, 5));
                    Target.SetActive(false);
                }

            }
        }
        
        
    }
}
