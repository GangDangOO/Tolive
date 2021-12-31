using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Equipment : MonoBehaviour
{
    private Inventory TheInven;
    private OkorNO theOOC;

    private const int WEAPON = 0, ARMOR=1, HELMET=2, GLOVE =3, BOOTS=4;
    public Text[] text; //스탯
    public Image[] img_slots;//장비 슬롯 아이콘
    public GameObject go_selected_Slot_UI; //선택된 장비 슬롯 (UI)
    public GameObject go_OOC;
    public GameObject go; //장비창 활성화

    public Item[] equipItemList; //장착된 장비 리스트 (equipItemList는 배열로 만든 이유는 배열에 [WEAPON],[ARMOR] 이런식으로 접근
                                 //                                                     equipItemList[0] == equipItemList[WEAPON]
    private int selectedSlot; //방향키로 어떤것이 선택되는지 알아야 하므로(선택된 장비 슬롯)
    public bool activated = false;
    private bool inputKey = true;
    GameObject Axe;
    GameObject Spear;
    GameObject Knife;
    GameObject Stick;
    GameObject S_Spear;
    GameObject S_Knife;
    GameObject Bow;
    GameObject Slingshot;
    GameObject Pickax;
    GameObject Touch;
    GameObject Torch;
    Stat A;
    Check check;
    void Start()
    {
        check = GameObject.FindObjectOfType<Check>();
        TheInven = FindObjectOfType<Inventory>();
        //스탯 정보
        theOOC = FindObjectOfType<OkorNO>();
        Touch = GameObject.Find("TouchField");
        A= GameObject.FindWithTag("Player").GetComponent<Stat>();
    }
    public void EquipItem(Item _item) { //장착
        string temp = _item.itemID.ToString(); //문자열로 바꾼 이유
        temp = temp.Substring(0, 3);
        switch (temp) {
            case "200": //무기
                EquipItemCheck(WEAPON, _item);
                break;
            case "201": //갑옷
                EquipItemCheck(ARMOR, _item);
                break;
            case "202": //투구
                EquipItemCheck(HELMET, _item);
                break;
            case "203": //장갑
                EquipItemCheck(GLOVE, _item);
                break;
            case "204": //신발
                EquipItemCheck(BOOTS, _item);
                break;
          
        }
    }
    public void EquipItemCheck(int _count, Item _item) {
        if(equipItemList[_count].itemID == 0) { //비어있으면
            equipItemList[_count] = _item;
        }
        else { //이미 장착하고 있을경우 기존에 장착된걸 빼고
            TheInven.EquipToInventory(equipItemList[_count]); //장비를 인벤토리로
            equipItemList[_count] = _item;
        }

    }
    public void ClearEquip() { //장비창에 이미지를 깔끔하게 하기위함
        Color color = img_slots[0].color; //장비창의 이미지 알파값을 0으로 하기위함
        color.a = 0f;
        for(int i=0; i<img_slots.Length; i++) {
            img_slots[i].sprite = null;
            img_slots[i].color = color;
        }

    }
    //public void SelectedSlot() {
    //    go_selected_Slot_UI.transform.position = img_slots[selectedSlot].transform.position;
    //}
    public void ShowEquip() {
        Color color = img_slots[0].color; //장착되면 보여 주는 함수
        color.a = 1f;
        for(int i=0; i<img_slots.Length; i++) {
            if(equipItemList[i].itemID != 0) { //고유넘버로 분별
                img_slots[i].sprite = equipItemList[i].itemIcon; //슬롯에 있는 sprite를 장착 아이템 icon으로 변경
                img_slots[i].color = color;                      //알파 값을 1로 조절
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inputKey) {
            if (Input.GetKeyDown(KeyCode.E)) {
                activated = !activated;
                A.DEFState.text = A.PlayerDEF.ToString();
                A.ATKState.text = A.PlayerATK.ToString();
                if (activated) { //활성화상태

                    //NOTMOVE()
                    //보일수 있게
                    Touch.SetActive(false);
                    go.SetActive(true);
                    //selectedSlot = 0; //첫번째 장비탭이 선택되게
                    //SelectedSlot();
                    ClearEquip();
                    ShowEquip();
                }
                else {//활성화가 아니면
                    //MOVE();
                    go.SetActive(false);
                    Touch.SetActive(true);
                    ClearEquip();
                }
            }

            if (activated) { //방향키에 따라 선택하는
                if (Input.GetKeyDown(KeyCode.S)) {
                    if (selectedSlot < img_slots.Length - 1)
                        selectedSlot++;
                    else
                        selectedSlot = 0;
                    //SelectedSlot();
                }
                else if (Input.GetKeyDown(KeyCode.D)) {
                    if (selectedSlot < img_slots.Length - 1)
                        selectedSlot++;
                    else
                        selectedSlot = 0;
                    //SelectedSlot();
                }
                else if (Input.GetKeyDown(KeyCode.A)) {
                    if (selectedSlot > 0)
                        selectedSlot--;
                    else
                        selectedSlot = img_slots.Length - 1;
                    //SelectedSlot();
                }
                else if (Input.GetKeyDown(KeyCode.W)) {
                    if (selectedSlot > 0)
                        selectedSlot--;
                    else
                        selectedSlot = img_slots.Length - 1;
                    //SelectedSlot();
                }
                else if (Input.GetKeyDown(KeyCode.R)) {
                    if (equipItemList[selectedSlot].itemID != 0) {//선택된 itemId가 0이 아닐때 (껍데기가 아닐때)
                        inputKey = false;
                        StartCoroutine(OKOR("해체", "취소"));
                    }
                }
            }
        }
    }
    IEnumerator OKOR(string _up, string _down) {
        go_OOC.SetActive(true);
        theOOC.ShowTwoChoice(_up,_down); //UI를 띄움
        yield return new WaitUntil(() => !theOOC.activated); //선택전 까지 대기
        if (theOOC.GetResult()) { //해체 버튼을 누르면
            if(equipItemList[0].itemID == 20001) { // 0=무기, 1=갑옷 , 2=투구, 3=장갑, 4=신발
                                                   //    5       4        1      2         3
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip);//빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20002) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20003) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20004) {
                Inventory.op.SetActive(false); 
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20005) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20006) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20007) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20008) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20009) {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[0].itemID == 20010)
            {
                Inventory.op.SetActive(false);
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[1].itemID == 20101) {//갑옷
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[1].itemID == 20102) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[1].itemID == 20103) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[1].itemID == 20104) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[2].itemID == 20201) {//투구
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[2].itemID == 20202) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[2].itemID == 20203) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[2].itemID == 20204) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[3].itemID == 20301) {//장갑
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[3].itemID == 20302) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[3].itemID == 20303) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[3].itemID == 20304) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[4].itemID == 20401) {//신발
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[4].itemID == 20402) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[4].itemID == 20403) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }
            if (equipItemList[4].itemID == 20404) {
                TheInven.EquipToInventory(equipItemList[selectedSlot]);
                equipItemList[selectedSlot] = new Item(0, "", "", Item.ItemType.Equip); //빈껍데기로
                ClearEquip();
                ShowEquip();
                inputKey = true; //방향키가 다시 가능해지게
                go_OOC.SetActive(false);//선택지를 비활성화
                yield break;
            }

        }
        else {
            go_OOC.SetActive(false);
        }
    }
    
    public void OnClickHuman(Button C) {
        if (C.name =="Human") {
            activated = !activated;
            A.DEFState.text = A.PlayerDEF.ToString();
            A.ATKState.text = A.PlayerATK.ToString();
            if (go.activeSelf == false) { //활성화상태
                check.Visible();
                Touch.SetActive(false);
                go.SetActive(true);
                selectedSlot = 0; //첫번째 장비탭이 선택되게
                //SelectedSlot();
                ClearEquip();
                ShowEquip();
            }
            else {//활성화가 아니면
                  //MOVE();
                go.SetActive(false);
                Touch.SetActive(true);
                ClearEquip();
                go_OOC.SetActive(false);
            }
        }
    } //장비창 활성화

    public void OnClickEquip(Button B) {
        if(B.name == "Slot1") { //투구
            selectedSlot = 2;
            
            if (equipItemList[selectedSlot].itemID != 0) {
                StartCoroutine(OKOR("해체", "취소"));
               
            }
        }
        if (B.name == "Slot2") { //장갑
            selectedSlot = 3;
            
            if (equipItemList[selectedSlot].itemID != 0) {
                StartCoroutine(OKOR("해체", "취소"));
                
            }
        }
        if (B.name == "Slot3") {//신발
            selectedSlot = 4;
            if (equipItemList[selectedSlot].itemID != 0) {
                StartCoroutine(OKOR("해체", "취소"));
               
            }
        }
        if (B.name == "Slot4") { //갑옷
            selectedSlot = 1;
            if (equipItemList[selectedSlot].itemID != 0) {
                StartCoroutine(OKOR("해체", "취소"));
                
            }
        }
        if (B.name == "Slot5") { //무기
            selectedSlot = 0;
            if (equipItemList[selectedSlot].itemID != 0) {
                StartCoroutine(OKOR("해체", "취소"));
                
            }
        }
        
    }
}
