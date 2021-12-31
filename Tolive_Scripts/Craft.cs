using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Craft : MonoBehaviour {
    GameObject Touch;
    public GameObject go;
    public Transform tf; //슬롯의 부모객체 (SlotList)
    GameObject[] Slots;
    private ItemManager theDatabase;
    private Inventory TheInven;
    private bool activated;
    //private aaa[] slots;
    public Text Description_Text;

    Button[] CraftButton;
    Text[] CraftText;

    int Wood, Stone, Stem, Rope, Leaf, Cloth, Fire, Poison, Tooth, Tear, Poo, Stick, Knife, Spear, Pinna, SoftLeather, Leather, HardLeather, Meat = 0;
    bool WoodB, StoneB, StemB, RopeB, LeafB, ClothB, FireB, PoisonB, ToothB, TearB, PooB, StickB, KnifeB, SpearB, PinnaB, SoftLeatherB, LeatherB, HardLeatherB, MeatB = false;
    Check check;
    private void Awake() {
        check = GameObject.FindObjectOfType<Check>();
        Slots = new GameObject[34];
        CraftButton = new Button[Slots.Length];
        CraftText = new Text[Slots.Length];
        for (int i = 0; i < Slots.Length; i++) {
            Slots[i] = GameObject.Find("CraftSlot" + i.ToString());
            CraftButton[i] = Slots[i].GetComponentInChildren<Button>();
            CraftText[i] = GameObject.Find(Slots[i].name + "/Button/Text").GetComponent<Text>();
            CraftText[i].text = "제작 불가능";
            CraftButton[i].enabled = false;
            Description_Text.text = "";
        }
    }

    void Start() {
        go.SetActive(false);
        theDatabase = FindObjectOfType<ItemManager>();
        Touch = GameObject.Find("TouchField");
        // TheInven = FindObjectOfType<Inventory>().GetComponent<Inventory>();
        //CraftButton = transform.GetComponent<Button>();
        //CraftText = transform.GetComponent<Text>();
        // slots = tf.GetComponentsInChildren<aaa>();

    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            activated = !activated;

            if (activated) {
                Touch.SetActive(false);
                go.SetActive(true);
                StartCoroutine(Craft_Active());
            }
            else {
                Touch.SetActive(true);
                go.SetActive(false);
            }
        }
    }
    IEnumerator Craft_Active() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {//나무조각
                Wood = Inventory.inventoryItemList[i].itemCount;
                WoodB = true;
            }
            else if (WoodB == false) {
                Wood = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3001) {//돌
                Stone = Inventory.inventoryItemList[i].itemCount;
                StoneB = true;
            }
            else if (StoneB == false) {
                Stone = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3004) {//줄기
                Stem = Inventory.inventoryItemList[i].itemCount;
                StemB = true;
            }
            else if (StemB == false) {
                Stem = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {//끈
                Rope = Inventory.inventoryItemList[i].itemCount;
                RopeB = true;
            }
            else if (RopeB == false) {
                Rope = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3006) {//잎
                Leaf = Inventory.inventoryItemList[i].itemCount;
                LeafB = true;
            }
            else if (LeafB == false) {
                Leaf = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3007) {//천
                Cloth = Inventory.inventoryItemList[i].itemCount;
                ClothB = true;
            }
            else if (ClothB == false) {
                Cloth = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 1005) {//불
                Fire = Inventory.inventoryItemList[i].itemCount;
                FireB = true;
            }
            else if (FireB == false) {
                Fire = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3008) {//독
                Poison = Inventory.inventoryItemList[i].itemCount;
                PoisonB = true;
            }
            else if (PoisonB == false) {
                Poison = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3012) {//날카로운 이빨
                Tooth = Inventory.inventoryItemList[i].itemCount;
                PoisonB = true;
            }
            else if (PoisonB == false) {
                Tooth = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3002) {//악어의 눈물
                Tear = Inventory.inventoryItemList[i].itemCount;
                TearB = true;
            }
            else if (TearB == false);
            {
                Tear = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3013) {//곰의 비료
                Poo = Inventory.inventoryItemList[i].itemCount;
                PooB = true;
            }
            else if (PooB == false) {
                Poo = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3014) {//지느러미
                Pinna = Inventory.inventoryItemList[i].itemCount;
                PinnaB = true;
            }
            else if (PinnaB == false) {
                Pinna = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 20001) {//막대기
                Stick ++;
                StickB = true;
            }
            else if (StickB == false) {
                Stick = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 20004) {//돌칼
                Knife++;
                KnifeB = true;
            }
            else if (KnifeB == false) {
                Knife = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 20005) {//돌창
                Spear++;
                SpearB = true;
            }
            else if (SpearB == false) {
                Spear = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3009) {//일반가죽
                SoftLeather = Inventory.inventoryItemList[i].itemCount;
                SoftLeatherB = true;
            }
            else if (SoftLeatherB == false) {
                SoftLeather = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3010) {//질긴가죽
                Leather = Inventory.inventoryItemList[i].itemCount;
                LeatherB = true;
            }
            else if (LeatherB == false) {
                Leather = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 3011) {//단단한가죽
                HardLeather = Inventory.inventoryItemList[i].itemCount;
                HardLeatherB = true;
            }
            else if (HardLeatherB == false) {
                HardLeather = 0;
            }
            if (Inventory.inventoryItemList[i].itemID == 1003) {//구운고기
                Meat = Inventory.inventoryItemList[i].itemCount;
                MeatB = true;
            }
            else if (MeatB == false) {
                Meat = 0;
            }

        }
        if (Wood >= 3) { //막대기
            CraftText[0].text = "제작 가능";
            CraftButton[0].enabled = true;

        }
        else {
            CraftText[0].text = "제작 불가능";
            CraftButton[0].enabled = false;
        }

        if (Stick >= 1 && Stone >= 2) { //돌도끼
            print("돌도끼 만들기");
            CraftText[1].text = "제작 가능";
            CraftButton[1].enabled = true;
        }
        else {
            CraftText[1].text = "제작 불가능";
            CraftButton[1].enabled = false;
        }

        if (Stick >= 2 && Stone >= 1) { //곡괭이
            print("곡괭이 만들기");
            CraftText[2].text = "제작 가능";
            CraftButton[2].enabled = true;
        }
        else {
            CraftText[2].text = "제작 불가능";
            CraftButton[2].enabled = false;
        }

        if (Stem >= 3) {//끈
            CraftText[3].text = "제작 가능";
            CraftButton[3].enabled = true;
        }
        else {
            CraftText[3].text = "제작 불가능";
            CraftButton[3].enabled = false;
        }

        if (Leaf >= 3) {//천
            CraftText[4].text = "제작 가능";
            CraftButton[4].enabled = true;
        }
        else {
            CraftText[4].text = "제작 불가능";
            CraftButton[4].enabled = false;
        }

        if (Wood >= 2 && Leaf >= 3) {//불
            CraftText[5].text = "제작 가능";
            CraftButton[5].enabled = true;
        }
        else {
            CraftText[5].text = "제작 불가능";
            CraftButton[5].enabled = false;
        }

        if (Poison >= 3 && Cloth >= 2) {//독주머니
            CraftText[6].text = "제작 가능";
            CraftButton[6].enabled = true;
        }
        else {
            CraftText[6].text = "제작 불가능";
            CraftButton[6].enabled = false;
        }

        if (Stone >= 4 && Leaf >= 3) {//돌칼
            CraftText[7].text = "제작 가능";
            CraftButton[7].enabled = true;
        }
        else {
            CraftText[7].text = "제작 불가능";
            CraftButton[7].enabled = false;
        }

        if (Knife >= 1 && Stick >= 2) {//창
            CraftText[8].text = "제작 가능";
            CraftButton[8].enabled = true;
        }
        else {
            CraftText[8].text = "제작 불가능";
            CraftButton[8].enabled = false;
        }

        if (Stick >= 1 && Rope >= 1) {//활
            CraftText[9].text = "제작 가능";
            CraftButton[9].enabled = true;
        }
        else {
            CraftText[9].text = "제작 불가능";
            CraftButton[9].enabled = false;
        }

        if (Wood >= 2 && Rope >= 1) {//새총
            CraftText[10].text = "제작 가능";
            CraftButton[10].enabled = true;
        }
        else {
            CraftText[10].text = "제작 불가능";
            CraftButton[10].enabled = false;
        }

        if (Wood >= 5 && Rope >= 4) {//물통
            CraftText[11].text = "제작 가능";
            CraftButton[11].enabled = true;
        }
        else {
            CraftText[11].text = "제작 불가능";
            CraftButton[11].enabled = false;
        }

        if (Knife >= 2 && Tooth >= 3) {//날카로운 돌칼
            CraftText[12].text = "제작 가능";
            CraftButton[12].enabled = true;
        }
        else {
            CraftText[12].text = "제작 불가능";
            CraftButton[12].enabled = false;
        }

        if (Spear >= 2 && Tooth >= 3) {//날카로운 창
            CraftText[13].text = "제작 가능";
            CraftButton[13].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[13].text = "제작 불가능";
            CraftButton[13].enabled = false;
        }

        if (Cloth >= 4 && Rope >= 2 && Wood >= 3) {//천갑옷
            CraftText[14].text = "제작 가능";
            CraftButton[14].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[14].text = "제작 불가능";
            CraftButton[14].enabled = false;
        }

        if (SoftLeather >= 5 && Rope >= 4) {//일반가죽 갑옷
            CraftText[15].text = "제작 가능";
            CraftButton[15].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[15].text = "제작 불가능";
            CraftButton[15].enabled = false;
        }

        if (Leather >= 5 && Rope >= 4) {//질긴가죽 갑옷
            CraftText[16].text = "제작 가능";
            CraftButton[16].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[16].text = "제작 불가능";
            CraftButton[16].enabled = false;
        }

        if (HardLeather >= 5 && Rope >= 4) {//단단한가죽 갑옷
            CraftText[17].text = "제작 가능";
            CraftButton[17].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[17].text = "제작 불가능";
            CraftButton[17].enabled = false;
        }

        if (Cloth >= 4 && Rope >= 2 && Wood >= 3) {//천투구
            CraftText[18].text = "제작 가능";
            CraftButton[18].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[18].text = "제작 불가능";
            CraftButton[18].enabled = false;
        }

        if (SoftLeather >= 5 && Rope >= 4) {//일반가죽 투구
            CraftText[19].text = "제작 가능";
            CraftButton[19].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[19].text = "제작 불가능";
            CraftButton[19].enabled = false;
        }

        if (Leather >= 5 && Rope >= 4) {//질긴가죽 투구
            CraftText[20].text = "제작 가능";
            CraftButton[20].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[20].text = "제작 불가능";
            CraftButton[20].enabled = false;
        }

        if (HardLeather >= 5 && Rope >= 4) {//단단한가죽 투구
            CraftText[21].text = "제작 가능";
            CraftButton[21].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[21].text = "제작 불가능";
            CraftButton[21].enabled = false;
        }

        if (Cloth >= 4 && Rope >= 2 && Wood >= 3) {//천장갑
            CraftText[22].text = "제작 가능";
            CraftButton[22].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[22].text = "제작 불가능";
            CraftButton[22].enabled = false;
        }

        if (SoftLeather >= 5 && Rope >= 4) {//일반가죽 장갑
            CraftText[23].text = "제작 가능";
            CraftButton[23].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[23].text = "제작 불가능";
            CraftButton[23].enabled = false;
        }

        if (Leather >= 5 && Rope >= 4) {//질긴가죽 장갑
            CraftText[24].text = "제작 가능";
            CraftButton[24].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[24].text = "제작 불가능";
            CraftButton[24].enabled = false;
        }

        if (HardLeather >= 5 && Rope >= 4) {//단단한가죽 장갑
            CraftText[25].text = "제작 가능";
            CraftButton[25].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[25].text = "제작 불가능";
            CraftButton[25].enabled = false;
        }

        if (Cloth >= 4 && Rope >= 2 && Wood >= 3) {//천신발
            CraftText[26].text = "제작 가능";
            CraftButton[26].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[26].text = "제작 불가능";
            CraftButton[26].enabled = false;
        }

        if (SoftLeather >= 5 && Rope >= 4) {//일반가죽 신발
            CraftText[27].text = "제작 가능";
            CraftButton[27].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[27].text = "제작 불가능";
            CraftButton[27].enabled = false;
        }

        if (Leather >= 5 && Rope >= 4) {//질긴가죽 신발
            CraftText[28].text = "제작 가능";
            CraftButton[28].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[28].text = "제작 불가능";
            CraftButton[28].enabled = false;
        }

        if (HardLeather >= 5 && Rope >= 4) {//단단한가죽 신발
            CraftText[29].text = "제작 가능";
            CraftButton[29].enabled = true;
        } //제작 가능시 나타 날때
        else {
            CraftText[29].text = "제작 불가능";
            CraftButton[29].enabled = false;
        }
        //신호탄, 화살 짱돌 횃불

        if (Fire >= 2 && Meat >=2 ) { //구운 고기
            CraftText[30].text = "제작 가능";
            CraftButton[30].enabled = true;
        }
        else {
            CraftText[30].text = "제작 불가능";
            CraftButton[30].enabled = false;
        }
        
        if(Wood >=1 && Stone >= 2) { //화살
            CraftText[31].text = "제작 가능";
            CraftButton[31].enabled = true;
        }
        else {
            CraftText[31].text = "제작 불가능";
            CraftButton[31].enabled = false;
        }
        if (Stone >= 2) { //짱돌
            CraftText[32].text = "제작 가능";
            CraftButton[32].enabled = true;
        }
        else {
            CraftText[32].text = "제작 불가능";
            CraftButton[32].enabled = false;
        }
        if (Stick >= 2 && Fire >=2) { //횃불
            CraftText[33].text = "제작 가능";
            CraftButton[33].enabled = true;
        }
        else {
            CraftText[33].text = "제작 불가능";
            CraftButton[33].enabled = false;
        }

        WoodB = StoneB = StemB = RopeB = LeafB = ClothB = FireB = PoisonB = ToothB = TearB = PooB = StickB = KnifeB = SpearB = PinnaB = SoftLeatherB = LeatherB = HardLeatherB = false;
        yield return null;
    }
    public void C1() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        Inventory.inventoryItemList.Add(new Item(20001, "막대기", "나무조각으로 만든 기본 무기", Item.ItemType.Equip));
        StartCoroutine(Craft_Active());
    } // 제작 버튼 0부터 ~ 끝까지
    public void C2() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20001) {
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3001) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20002 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20002, "돌도끼", "나무를 벨수있는 강한도끼", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    }
    public void C3() {
        int countS1 = 2;
        int countS2 = 1;
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20001 && countS1 != 0) { // 막대기
                Inventory.inventoryItemList.RemoveAt(i);
                countS1--;
                i--;
            }
            if (Inventory.inventoryItemList[i].itemID == 3001 && countS2 != 0) { // 돌
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
                countS2 = 0;
                i--;
            }
        }
        Inventory.inventoryItemList.Add(new Item(20003, "곡괭이", "돌을 캘수 있는 곡괭이", Item.ItemType.Equip));
        StartCoroutine(Craft_Active());
    }
    public void C4() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3004) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3005 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(3005, "끈", "줄기를 엮어서 만들수 있다", Item.ItemType.ETC));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    }
    public void C5() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3006) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                if (Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                    Inventory.inventoryItemList[i].itemCount++;
                    StartCoroutine(Craft_Active());
                    return;
                }
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(3007, "천", "잎을 사용하여 만들수 있다", Item.ItemType.ETC));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C6() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3006) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1005 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1005, "불", "주위를 밝혀준다", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C7() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3008) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1004 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1004, "독주머니", "전갈의 독을 사용할수 있게 해준다", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C8() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3001) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3006) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20004 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20004, "돌칼", "돌로 만든 칼", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C9() {
        int count20001 = 2;
        int count20004 = 1;
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20001 && count20001 != 0) {
                Inventory.inventoryItemList.RemoveAt(i);
                count20001--;
                i--;
            }
            if (Inventory.inventoryItemList[i].itemID == 20004 && count20004 != 0) {
                Inventory.inventoryItemList.RemoveAt(i);
                count20004--;
                i--;
            }
        }
        Inventory.inventoryItemList.Add(new Item(20005, "창", "막대기로 이용한 창", Item.ItemType.Equip));
        StartCoroutine(Craft_Active());
    }
    public void C10() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20001) {
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20006 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20006, "활", "투박해보이지만 강력한 활", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C11() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20007 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20007, "새총", "기본 사거리가 늘어난다", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C12() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1002 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1002, "물통", "갈증을 해소시켜준다", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    }
    public void C13() {
        int count20004 = 2;
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3012) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 20004 && count20004 !=0) {
                Inventory.inventoryItemList.RemoveAt(i);
                count20004--;
                i--;
            }
        }
        Inventory.inventoryItemList.Add(new Item(20008, "날카로운 돌칼", "돌칼 보다 더 날카롭다", Item.ItemType.Equip));
        StartCoroutine(Craft_Active());
    }
    public void C14() {
        int count20005 = 2;
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3012) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 20005 && count20005 != 0) {
                Inventory.inventoryItemList.RemoveAt(i);
                count20005--;
                i--;
            }
        }
        Inventory.inventoryItemList.Add(new Item(20009, "날카로운 창", "창보다 더 날카롭다", Item.ItemType.Equip));
        StartCoroutine(Craft_Active());
    } //날카로운 창
    public void C15() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20101 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20101, "천 갑옷", "천으로 만든 갑옷", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //천 갑옷
    public void C16() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3009) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20102 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20102, "일반 가죽 갑옷", "일반 가죽으로 만든 갑옷", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //일반 갑옷
    public void C17() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3010) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20103 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20103, "질긴 갑옷", "질긴 가죽으로 만든 갑옷", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    } //질긴 갑옷
    public void C18() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3011) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20104 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20104, "단단한 갑옷", "단단한 가죽으로 만든 갑옷", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    } //단단한 갑옷
    public void C19() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20201 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20201, "천 투구", "천으로 만든 투구", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    } //천 투구
    public void C20() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3009) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20202 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20202, "일반 가죽 투구", "일반 가죽으로 만든 투구", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //일반 투구
    public void C21() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3010) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20203 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20203, "질긴 투구", "질긴 가죽으로 만든 투구", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
        StartCoroutine(Craft_Active());
    } //질긴 투구
    public void C22() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3011) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20204 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20204, "단단한 투구", "단단한 가죽으로 만든 투구", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //단단한 투구
    public void C23() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20301 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20301, "천 장갑", "천으로 만든 장갑", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //천 장갑
    public void C24() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3009) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20302 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20302, "일반 가죽 장갑", "일반 가죽으로 만든 장갑", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //일반 장갑
    public void C25() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3010) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20303 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20303, "질긴 장갑", "질긴 가죽으로 만든 장갑", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //질긴 장갑
    public void C26() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3011) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20304 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20304, "단단한 장갑", "단단한 가죽으로 만든 장갑", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //단단한 장갑
    public void C27() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3007) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 3;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20401 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20401, "천 신발", "천으로 만든 신발", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //천 신발
    public void C28() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3009) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20402 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20402, "일반 가죽 신발", "일반 가죽으로 만든 신발", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //일반 신발
    public void C29() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3010) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20403 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20403, "질긴 신발", "질긴 가죽으로 만든 신발", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //질긴 신발
    public void C30() {
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3011) {
                Inventory.inventoryItemList[i].itemCount -= 5;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3005) {
                Inventory.inventoryItemList[i].itemCount -= 4;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20404 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20404, "단단한 신발", "단단한 가죽으로 만든 신발", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //단단한 신발
    public void C31() { //구운 고기
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1003) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 1005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1006 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1006, "구운 고기", "굶주림과 체력을 크게 회복해준다.", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //신호탄
    public void C32() {
            for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3003) {
                Inventory.inventoryItemList[i].itemCount -= 1;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 3001) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1007 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1007, "화살", "활과 함께 사용하는 화살이다", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //화살
    public void C33() { 
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 3001) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 1008 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(1008, "짱돌", "새총과 함께 사용하는 돌멩이다", Item.ItemType.Use));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //짱돌
    public void C34() { 
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20001) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
            if (Inventory.inventoryItemList[i].itemID == 1005) {
                Inventory.inventoryItemList[i].itemCount -= 2;
                if (Inventory.inventoryItemList[i].itemCount < 1) {
                    Inventory.inventoryItemList.RemoveAt(i);
                    i--;
                }
            }
        }
        for (int i = 0; i < Inventory.inventoryItemList.Count; i++) {
            if (Inventory.inventoryItemList[i].itemID == 20010 && Inventory.inventoryItemList[i].itemType != Item.ItemType.Equip) {
                Inventory.inventoryItemList[i].itemCount++;
                StartCoroutine(Craft_Active());
                return;
            }
            if (i == Inventory.inventoryItemList.Count - 1) {
                Inventory.inventoryItemList.Add(new Item(20010, "횃불", "주변을 환하게 밝혀준다", Item.ItemType.Equip));
                StartCoroutine(Craft_Active());
                return;
            }
        }
    } //횃불
    public void OnClickCraft(Button A) {
        if (A.name == "Craft") {
            activated = !activated;

            if (go.activeSelf == false) {
                check.Visible();
                Touch.SetActive(false);
                go.SetActive(true);
                StartCoroutine(Craft_Active());
            }
            else {
                Touch.SetActive(true);
                go.SetActive(false);
            }


        }
    }

    public void OnMouseEnter1() { //막대기
        Description_Text.text = "나무조각 3개 필요";
    }
    public void OnMouseEnter2() { //돌도끼
        Description_Text.text = "막대기 1개,돌 2개 필요";
    }
    public void OnMouseEnter3() { //곡괭이
        Description_Text.text = "막대기 2개,돌 1개 필요";
    }
    public void OnMouseEnter4() { //끈
        Description_Text.text = "줄기 3개 필요";
    }
    public void OnMouseEnter5() { //천
        Description_Text.text = "잎 3개 필요";
    }
    public void OnMouseEnter6() { //불
        Description_Text.text = "나무조각 2개,잎 3개 필요";
    }
    public void OnMouseEnter7() {//독주머니
        Description_Text.text = "독 3개,천 2개 필요";
    }
    public void OnMouseEnter8() {//돌칼
        Description_Text.text = "돌 4개,잎 3개 필요";
    }
    public void OnMouseEnter9() {//돌창
        Description_Text.text = "돌칼 1개,막대기 2개";
    }
    public void OnMouseEnter10() {//활
        Description_Text.text = "막대기 1개,끈 1개 필요";
    }
    public void OnMouseEnter11() {//새총
        Description_Text.text = "나무조각 1개,끈 1개 필요";
    }
    public void OnMouseEnter12() {//물통
        Description_Text.text = "나무조각 5개,끈 4개 필요";
    }
    public void OnMouseEnter13() {//날카로운 돌칼
        Description_Text.text = "돌칼 2개,날카로운이빨 3개 필요";
    }
    public void OnMouseEnter14() {
        Description_Text.text = "돌창 2개,날카로운이빨 3개 필요";
    }
    public void OnMouseEnter15() {//천갑옷
        Description_Text.text = "천 4개,끈 2개,나무조각 3개 필요";
    }
    public void OnMouseEnter16() {//일반가죽갑옷
        Description_Text.text = "일반가죽 5개,끈 4개 필요";        
    }
    public void OnMouseEnter17() {//질긴가죽갑옷
        Description_Text.text = "질긴가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter18() {//단단한가죽갑옷
        Description_Text.text = "단단한가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter19() {//천투구
        Description_Text.text = "천 4개,끈 2개,나무조각 3개 필요";
    }
    public void OnMouseEnter20() {//일반가죽투구
        Description_Text.text = "일반가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter21() {//질긴가죽투구
        Description_Text.text = "질긴가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter22() {//단단한가죽투구
        Description_Text.text = "단단한가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter23() {//천장갑
        Description_Text.text = "천 4개,끈 2개,나무조각 3개 필요";
    }
    public void OnMouseEnter24() {//일반가죽장갑
        Description_Text.text = "일반가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter25() {//질긴가죽장갑
        Description_Text.text = "질긴가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter26() {//단단한가죽장갑
        Description_Text.text = "단단한가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter27() {//천신발
        Description_Text.text = "천 4개,끈 2개,나무조각 3개 필요";
    }
    public void OnMouseEnter28() {//일반가죽신발
        Description_Text.text = "일반가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter29() {//질긴가죽신발
        Description_Text.text = "질긴가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter30() {//단단한가죽신발
        Description_Text.text = "단단한가죽 5개,끈 4개 필요";
    }
    public void OnMouseEnter31() {//신호탄 //Poo >= 1 && Tear >=2 && Pinna >=2 && Tooth >=3
        Description_Text.text = "고기 2개,불 2개 필요";
    }
    public void OnMouseEnter32() {//화살
        Description_Text.text = "나무조각 1개,돌 2개 필요";
    }
    public void OnMouseEnter33() {//짱돌
        Description_Text.text = "돌 2개 필요";
    }
    public void OnMouseEnter34() {//횃불
        Description_Text.text = "막대기 2개,불 2개 필요";
    }
    
}

