using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Inventory : MonoBehaviour
{
    /*사운드
    private AudioManager theAudio;
    public string key_sound;
    public string enter_sound;
    public string cancel_sound;
    public string open_sound;
    public string beep_sound;
    */

    //private OrderManger theorder; //캐릭터 움직임
    public static Inventory instance;
    private ItemManager theDatabase;
    private InventorySlot[] slots; //인벤토리 슬롯들
    [HideInInspector]
    public static List<Item> inventoryItemList = new List<Item>(); //플레이어가 소지한 아이템 리스트
    //편의를 위해
    private List<Item> inventoryTabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트
    private OkorNO theOOC;
    private Equipment theEquip;

    GameObject MainCamera;
    GameObject TouchCamera;

    public Text Description_Text; //부연설명
    public string[] tabDescription; //탭 부연 설명

    [HideInInspector] public static GameObject op;
    GameObject hand;
    GameObject body;
    GameObject foot;
    GameObject head;
    GameObject leg;


    Stat asd;


    public Transform tf; //슬롯의 부모객체 (SlotList)

    public GameObject go; //인벤토리 활성화 비활성화
    public GameObject[] selectedTabImages; //탭의 효과 (탭 안에 있는 판넬)
    public GameObject go_OOC; //선택지 활성 비활성

    private int selectedItem; //선택된 아이템
    private int selectedTab; //선택된 탭.
    public static int w = 0;
    int r = 0;
    public int a = 0;
    public int b = 0;
    public int c = 0;
    public int d = 0;
    

    private bool activated; //인벤토리 활성화시 true;
    private bool tabActivated; //탭 활성화시 true;
    private bool itemActivated; //아이템 활성화시 true;
    private bool stopKeyInput; //키입력 제한(아이템을 소비할때(독아이템), 질의가 나올텐데 그때 키입력 방지)
    private bool preventExec; //중복실행 제한

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    GameObject Axe;
    GameObject Spear;
    GameObject Knife;
    GameObject Stick;
    GameObject S_Spear;
    GameObject S_Knife;
    GameObject Bow;
    GameObject Slingshot;
    GameObject Pickax;
    GameObject Torch;
    GameObject Touch;
    GameObject ZoomButton;

    Check check;

    void Awake() {
        check = GameObject.FindObjectOfType<Check>();
        Axe = GameObject.Find("Axe");
        Spear = GameObject.Find("Spear");
        Knife = GameObject.Find("Knife");
        Stick = GameObject.Find("Stick");
        S_Spear = GameObject.Find("S_Spear");
        S_Knife = GameObject.Find("S_Knife");
        Bow = GameObject.Find("Bow");
        Slingshot = GameObject.Find("Slingshot");
        Pickax = GameObject.Find("Pickax");
        op = GameObject.Find("op");
        head = GameObject.Find("Head");
        body = GameObject.Find("Body");
        hand = GameObject.Find("Hand");
        leg = GameObject.Find("Leg");
        foot = GameObject.Find("Foot");
        Torch = GameObject.Find("Torch");
        asd = GameObject.FindWithTag("Player").GetComponent<Stat>();
        ZoomButton = GameObject.Find("Zoom");
        TouchCamera = GameObject.FindGameObjectWithTag("Zoom");
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Start is called before the first frame update
    void Start()
    {
        inventoryItemList.Add(new Item(1007, "화살", "활과 함께 사용하는 화살이다", Item.ItemType.Use, 20)); //Arrow
        inventoryItemList.Add(new Item(1008, "짱돌", "새총과 함께 사용하는 돌멩이다", Item.ItemType.Use, 20)); //SlingRock
        inventoryItemList.Add(new Item(20006, "활", "투박해보이지만 강력한 활", Item.ItemType.Equip)); //Bow
        inventoryItemList.Add(new Item(20009, "날카로운 창", "창보다 더 날카롭다", Item.ItemType.Equip)); //S_Spear
        inventoryItemList.Add(new Item(20010, "횃불", "주변을 환하게 밝혀준다", Item.ItemType.Equip));//Torch
        inventoryItemList.Add(new Item(1002, "물통", "갈증을 해소시켜준다", Item.ItemType.Use, 3));
        inventoryItemList.Add(new Item(1006, "구운 고기", "굶주림과 체력을 크게 회복해준다.", Item.ItemType.Use, 3));
        inventoryItemList.Add(new Item(20001, "막대기", "나무조각으로 만든 기본 무기", Item.ItemType.Equip)); //Stick
        inventoryItemList.Add(new Item(20002, "돌도끼", "나무를 벨수있는 강한도끼", Item.ItemType.Equip)); //Axe
        inventoryItemList.Add(new Item(20003, "곡괭이", "돌을 캘수 있는 곡괭이", Item.ItemType.Equip)); //Pickax
        inventoryItemList.Add(new Item(20004, "돌칼", "돌로 만든 칼", Item.ItemType.Equip)); //Knife
        inventoryItemList.Add(new Item(20005, "창", "막대기로 이용한 창", Item.ItemType.Equip)); //Spear
        inventoryItemList.Add(new Item(20006, "활", "투박해보이지만 강력한 활", Item.ItemType.Equip)); //Bow
        inventoryItemList.Add(new Item(20007, "새총", "기본 사거리가 늘어난다", Item.ItemType.Equip)); //Slingshot
        inventoryItemList.Add(new Item(20008, "날카로운 돌칼", "돌칼 보다 더 날카롭다", Item.ItemType.Equip)); //S_Knife
        inventoryItemList.Add(new Item(20009, "날카로운 창", "창보다 더 날카롭다", Item.ItemType.Equip)); //S_Spear
        inventoryItemList.Add(new Item(20010, "횃불", "주변을 환하게 밝혀준다", Item.ItemType.Equip));//Torch
        inventoryItemList.Add(new Item(20101, "천갑옷", "천으로 만든 갑옷", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(20201, "천투구", "천으로 만든 투구", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(20301, "천장갑", "천으로 만든 장갑", Item.ItemType.Equip));
        inventoryItemList.Add(new Item(20401, "천신발", "천으로 만든 신발", Item.ItemType.Equip));

        Axe.SetActive(false);
        Spear.SetActive(false);
        Knife.SetActive(false);
        Stick.SetActive(false);
        S_Spear.SetActive(false);
        S_Knife.SetActive(false);
        Bow.SetActive(false);
        Slingshot.SetActive(false);
        Pickax.SetActive(false);
        Torch.SetActive(false);
        ZoomButton.SetActive(false);

        instance = this;
        theDatabase = FindObjectOfType<ItemManager>();
        //theorder = FindObjectofType<OrderManager>();
        theOOC = FindObjectOfType<OkorNO>();
        theEquip = FindObjectOfType<Equipment>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
        Touch = GameObject.Find("TouchField");



    }
    public void EquipToInventory(Item _item) { //장착되는 아이템에 함수를 호출하기위해
        inventoryItemList.Add(_item);
    }
    /*public void CraftToInventory (Item _item) { //조합된 아이템에 함수를 호출하기 위해
        inventoryItemList.Add(_item);
    }*/
    public void GetAnItem(int _itemID, int _count = 1) {

        for (int i = 0; i < theDatabase.itemList.Count; i++) { //데이터베이스 아이템 검색
            if (_itemID == theDatabase.itemList[i].itemID) { //데이터베이스에 아이템 발견
                for (int j = 0; j < inventoryItemList.Count; j++) {//소지품에 같은 아이템이 있는지 확인
                    if (inventoryItemList[j].itemID == _itemID) {//소지품에 같은 아이템이 있다 - > 갯수만 증감
                        if (inventoryItemList[j].itemType == Item.ItemType.Use) {

                            inventoryItemList[j].itemCount += _count;

                        }else if (inventoryItemList[j].itemType == Item.ItemType.ETC) {

                            inventoryItemList[j].itemCount += _count;

                        } else { //장비일때
                            inventoryItemList.Add(theDatabase.itemList[i]);

                        }
                        return;
                    }
                }
                inventoryItemList.Add(theDatabase.itemList[i]); //소지품에 해당 아이템 추가
                inventoryItemList[inventoryItemList.Count - 1].itemCount = _count;
                return;
            }
        }
        Debug.LogError("데이터베이스에 해당 ID값을 가진 아이템이 존재하지 않습니다.");
    } //아이템 추가
    public void RemoveSlot() {
        for ( int i=0; i< slots.Length; i++) {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } //인벤토리 슬롯 초기화

    public void ShowTab() {
        RemoveSlot();
        SelectedTab();
    } //탭 보여주기 (탭활성화)
    public void SelectedTab() {
        //StopAllCoroutines(); //기존 코루틴 모두 정지
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 1f;
        for(int i=0; i< selectedTabImages.Length; i++) {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Description_Text.text = tabDescription[selectedTab]; //탭에대한 설명
        StartCoroutine(SelectedTabEffectCoroutine());
    } //선택된 탭을 제외 하고 다른 모든 탭의 컬러 알파값 0으로 조정
    IEnumerator SelectedTabEffectCoroutine() {
        while (tabActivated) { //선택할수 있는 탭이 잇을경우 탭을 활성화
            Color color = selectedTabImages[0].GetComponent<Image>().color;
           /*while (color.a < 0.5f) {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;//선택된 탭만 반짝거리도록
                yield return waitTime;
            }
            while (color.a >0f) {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
            }*/
                yield return waitTime;
        }
    } //선택된 탭 반짝임 효과

    public void ShowItem() {
        inventoryTabList.Clear(); //탭리스트 초기화, 
        RemoveSlot(); 
        selectedItem = 0; //탭을 선택후 첫번째가 선택되게

        switch (selectedTab) { 
            case 0:
                for(int i =0; i<inventoryItemList.Count; i++) { //모든 인벤토리 아이템을 검색
                    if (Item.ItemType.Use == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 1:
                for (int i = 0; i < inventoryItemList.Count; i++) {
                    if (Item.ItemType.Equip == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 2:
                for (int i = 0; i < inventoryItemList.Count; i++) {
                    if (Item.ItemType.ETC == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            
        } //탭에 따른 아이템 분류, 그것을 인벤토리 탭 리스트에 추가

        for(int i =0; i<inventoryTabList.Count; i++) {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
        } //인벤토리 탭 리스트의 내용을 인벤토리 슬롯에 추가

        SelectedItem();
    } //아이템 활성화(inventoryTabList에 조건에 맞는 아이템들만 넣어주고, 인벤토리 슬롯에 출력)
    public void SelectedItem() {
        ///StopAllCoroutines();
        if(inventoryTabList.Count > 0) { //아이템이 창에 있을경우
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for(int i= 0; i<inventoryTabList.Count; i++) {
                slots[i].selected_Item.GetComponent<Image>().color = color;
            }
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else { //아이템이 하나도 없을 경우
            Description_Text.text = "해당 타입의 아이템을 소지하고 있지않습니다.";
        }
    }//선택된 아이템을 제외하고, 다른 모든 탭의 컬러 알파값을 0으로 조정(선택된것만 반짝)
    IEnumerator SelectedItemEffectCoroutine() {
        while (itemActivated) {
            Color color = slots[0].GetComponent<Image>().color;
            while (color.a < 0.5f) {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f) {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
        }
    } //선택된 아이템 반짝임 효과

    public int StickATK = 5;
    public int AxeATK = 10;
    public int PickaxATK = 10;
    public int TorchATK = 12;
    public int KnifeATK = 15;
    public int SpearATK = 15;
    public int BowATK = 25;
    public int SlingATK = 15;
    public int S_KnifeATK = 25;
    public int S_SpearATK = 30;
    public int AnotherRAN = 0;
    

    public int EasyDEF = 1;
    public int NormalDEF = 2;
    public int HardDEF = 3;
    public int HellDEF = 4; // q w e r P = q+w+e+r1


   
    void Update()
    {
        if (!stopKeyInput) {
            if (Input.GetKeyDown(KeyCode.I)) {
                activated = !activated;
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    Inventory.inventoryItemList[i].itemIcon = Resources.Load("RPG_inventory_icons/" + Inventory.inventoryItemList[i].itemID.ToString(), typeof(Sprite)) as Sprite;
                }
                if (activated) {  //true일경우
                    Touch.SetActive(false);
                    //theOrder.NotMove(); //캐릭터를 움직이지 못하게
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true; //탭 먼저 고를수 있도록
                    itemActivated = false;
                    ShowTab();


                }
                else { //false일경우
                    StopAllCoroutines();
                    go.SetActive(false); //안쓴다는 의미
                    Touch.SetActive(true);
                    tabActivated = false;
                    itemActivated = false;
                    //theOrder.Move(); //캐릭터를 움직이게

                }
            } //인벤토리 활성화 시 
            if (activated) {
                if (tabActivated) {
                    if (Input.GetKeyDown(KeyCode.RightArrow)) {
                        if (selectedTab < selectedTabImages.Length - 1) {
                            selectedTab++;
                        }
                        else {
                            selectedTab = 0;
                        }
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                        if (selectedTab > 0) {
                            selectedTab--;
                        }
                        else {
                            selectedTab = selectedTabImages.Length - 1;
                        }
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.Z)) { //결정 하는 경우
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true; //아이템 활성화
                        tabActivated = false;
                        preventExec = true; //true일때 키입력 x
                        
                        ShowItem();
                    }
                } //탭 활성화시 키입력 처리

                else if (itemActivated) { //아이템 활성화 시
                    if (inventoryTabList.Count > 0) {
                        if (Input.GetKeyDown(KeyCode.DownArrow)) { //아래버튼 눌리면
                            if (selectedItem < inventoryTabList.Count - 2) {
                                selectedItem += 2;
                            }
                            else {
                                selectedItem %= 2;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                            if (selectedItem > 1) {
                                selectedItem -= 2;
                            }
                            else {
                                selectedItem = inventoryTabList.Count - 1 - selectedItem;
                            }
                            SelectedItem();

                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                            if (selectedItem < inventoryTabList.Count - 1) {
                                selectedItem++;
                            }
                            else {
                                selectedItem = 0;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                            if (selectedItem > 0) {
                                selectedItem--;
                            }
                            else {
                                selectedItem = inventoryTabList.Count - 1;
                            }
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.Z) && !preventExec) {

                            if (selectedTab == 0) {
                                

                                StartCoroutine(OKOR("사용","취소"));
                            }
                            else if (selectedTab == 1) { //장비 탭인경우 장비 장착
                                
                               

                                StartCoroutine(OKOR("장착","취소"));             
                            }
                            else { //재료와 조합탭은

                                print("사용할수 없는 아이템 입니다.");
                            }
                        }
                    }
                        if (Input.GetKeyDown(KeyCode.X)) { //뒤로 넘어가는 (탭을 고르는 단계로)
                            //StopAllCoroutines();
                            itemActivated = false;
                            tabActivated = true;
                            ShowTab();
                        }
                       
                } //아이템 활성화시 키입력

                if (Input.GetKeyUp(KeyCode.Z)) { //중복 실행 방지
                    preventExec = false;
                } 
            }

        } 
    }

    IEnumerator OKOR(string _up,string _down) {
        stopKeyInput = true;
        go_OOC.SetActive(true);
        theOOC.ShowTwoChoice(_up, _down); //UI를 띄움
        yield return new WaitUntil(() => !theOOC.activated); //선택전 까지 대기
        if (theOOC.GetResult()) { //사용되었으면
            for (int i = 0; i < inventoryItemList.Count; i++) { //인벤토리에서 줄이기위한
                if (inventoryItemList[i].itemID == inventoryTabList[selectedItem].itemID) { 
                    if(selectedTab == 0) { //소비아이템일경우
                        print(inventoryItemList[i].itemID);
                        theDatabase.UseItem(inventoryItemList[i].itemID);
                        if (inventoryItemList[i].itemCount > 1) { //아이템이 한개보다 많을때
                            inventoryItemList[i].itemCount--;     //감소
                        }
                        else {
                            inventoryItemList.RemoveAt(i);    //없을경우 슬롯을 제거
                        }

                        ShowItem();
                        break;
                    } else if(selectedTab == 1) { //장비 아이템일 경우
                        if(inventoryItemList[i].itemID == 20001) {

                            op.SetActive(false);
                            op = Stick;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            BoxCollider A = Inventory.op.GetComponent<BoxCollider>();


                            asd.PlayerATK += -w + StickATK;
                            print(StickATK);
                            w = StickATK;
                            
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20002) {
                            op.SetActive(false);
                            op = Axe;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + AxeATK;
                            w = AxeATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        } 
                        if (inventoryItemList[i].itemID == 20003) {
                            op.SetActive(false);
                            op = Pickax;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            BoxCollider A = Inventory.op.GetComponent<BoxCollider>();
                            A.enabled = false;

                            asd.PlayerATK += -w + PickaxATK;
                            w = PickaxATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        } 
                        if (inventoryItemList[i].itemID == 20004) {
                            op.SetActive(false);
                            op = Knife;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + KnifeATK;
                            w = KnifeATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        } 
                        if (inventoryItemList[i].itemID == 20005) {
                            op.SetActive(false);
                            op = Spear;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + SpearATK;
                            w = SpearATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        } 
                        if (inventoryItemList[i].itemID == 20006 && SceneManager.GetActiveScene().name == "Scene 1") {//활
                            op.SetActive(false);
                            op = Bow;
                            op.SetActive(true);
                            ZoomButton.SetActive(true);

                            asd.PlayerATK += -w + BowATK;
                            w = BowATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + BowRAN;
                            r = BowRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20006 && SceneManager.GetActiveScene().name == "Cave") {//활
                            op.SetActive(false);
                            op = Bow;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);

                            asd.PlayerATK += -w + BowATK;
                            w = BowATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + BowRAN;
                            r = BowRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20007 && SceneManager.GetActiveScene().name == "Scene 1") {//새총
                            op.SetActive(false);
                            op = Slingshot;
                            op.SetActive(true);
                            ZoomButton.SetActive(true);

                            asd.PlayerATK += -w + SlingATK;
                            w = SlingATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + SlingRAN;
                            r = SlingRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20007 && SceneManager.GetActiveScene().name == "Cave") {//새총
                            op.SetActive(false);
                            op = Slingshot;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);

                            asd.PlayerATK += -w + SlingATK;
                            w = SlingATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + SlingRAN;
                            r = SlingRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20008) {
                            op.SetActive(false);
                            op = S_Knife;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + S_KnifeATK;
                            w = S_KnifeATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        } 
                        if (inventoryItemList[i].itemID == 20009) {
                            op.SetActive(false);
                            op = S_Spear;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + S_SpearATK;
                            w = S_SpearATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20010)
                        {
                            op.SetActive(false);
                            op = Torch;
                            op.SetActive(true);
                            ZoomButton.SetActive(false);
                            MainCamera.SetActive(true);
                            TouchCamera.SetActive(false);

                            asd.PlayerATK += -w + TorchATK;
                            w = TorchATK;
                            asd.ATKState.text = asd.PlayerATK.ToString();

                            /*asd.PlayerRAN += -r + AnotherRAN;
                            r = AnotherRAN;
                            asd.RANState.text = asd.PlayerRAN.ToString();*/

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20101) {
                            //body.SetActive(false);

                            //body.SetActive(true);

                            asd.PlayerDEF += -a + EasyDEF;
                            a = EasyDEF;
                            
                            //asd.DEFState.text = asd.PlayerDEF.ToString();
                            
                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20102) {

                            //body.SetActive(false);

                            //body.SetActive(true);

                            asd.PlayerDEF += -a + NormalDEF;
                            a = NormalDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20103) {

                            //body.SetActive(false);

                            //body.SetActive(true);

                            asd.PlayerDEF += -a + HardDEF;
                            a = HardDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20104) {

                            //body.SetActive(false);

                            //body.SetActive(true);

                            asd.PlayerDEF += -a + HellDEF;
                            a = HellDEF;
                            

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20201) {

                            //head.SetActive(false);

                            //head.SetActive(true);

                            asd.PlayerDEF += -b + EasyDEF;
                            b = EasyDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20202) {

                            //head.SetActive(false);

                            //head.SetActive(true);

                            asd.PlayerDEF += -b + NormalDEF;
                            b = NormalDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20203) {

                            //head.SetActive(false);

                            //head.SetActive(true);

                            asd.PlayerDEF += -b + HardDEF;
                            b = HardDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20204) {

                            //head.SetActive(false);

                            //head.SetActive(true);

                            asd.PlayerDEF += -b + HellDEF;
                            b = HellDEF;
                            asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20301) {

                            //hand.SetActive(false);

                            //hand.SetActive(true);

                            asd.PlayerDEF += -c + EasyDEF;
                            c = EasyDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20302) {

                            //hand.SetActive(false);

                            //hand.SetActive(true);

                            asd.PlayerDEF += -c + NormalDEF;
                            c = NormalDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20303) {

                            //hand.SetActive(false);

                            //hand.SetActive(true);

                            asd.PlayerDEF += -c + HardDEF;
                            c = HardDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20304) {

                            //hand.SetActive(false);

                            //hand.SetActive(true);

                            asd.PlayerDEF += -c + HellDEF;
                            c = HellDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20401) {

                            //foot.SetActive(false);

                            //foot.SetActive(true);

                            asd.PlayerDEF += -d + EasyDEF;
                            d = EasyDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20402) {

                            //foot.SetActive(false);

                            //foot.SetActive(true);

                            asd.PlayerDEF += -d + NormalDEF;
                            d = NormalDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20403) {

                            //foot.SetActive(false);

                            //foot.SetActive(true);

                            asd.PlayerDEF += -d + HardDEF;
                            d = HardDEF;
                            //asd.DEFState.text = asd.PlayerDEF.ToString();

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                        if (inventoryItemList[i].itemID == 20404) {

                            //foot.SetActive(false);

                            //foot.SetActive(true);

                            asd.PlayerDEF += -d + HellDEF;
                            d = HellDEF;
                            

                            theEquip.EquipItem(inventoryItemList[i]); //선택한 아이템을 보냄
                            inventoryItemList.RemoveAt(i); //장착햇으니 인벤토리에서 지움
                            ShowItem();//
                            break;
                        }
                    } //장비아이템인 경우
                }
            }
        }
        stopKeyInput = false; //방향키가 다시 가능해지게
        go_OOC.SetActive(false);//선택지를 비활성화
    }
    public void OnTabClik(Button A) {
        
        if (A.name == "Selected_Tab") { //결정 하는 경우
            selectedTab = 0;
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 0.0f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
            itemActivated = true; //아이템 활성화
            tabActivated = false;
            preventExec = true; //true일때 키입력 x
            ShowItem();
            
            
        }else {
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 1f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
        }
        if (A.name == "Selected_Tab1") { //결정 하는 경우
            selectedTab = 1;
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 0.0f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
            itemActivated = true; //아이템 활성화
            tabActivated = false;
            preventExec = true; //true일때 키입력 x
            
            ShowItem();
        }
        else {
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 1f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
        }
        if (A.name == "Selected_Tab2") { //결정 하는 경우
            selectedTab = 2;
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 1f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
            itemActivated = true; //아이템 활성화
            tabActivated = false;
            preventExec = true; //true일때 키입력 x

            ShowItem();
        }
        else {
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            color.a = 1f;
            selectedTabImages[selectedTab].GetComponent<Image>().color = color;
        }

    } //마우스로 탭 클릭하는 경우
    public void OnClickBag(Button B) {
        if (B.name == "Bag") {
            activated = !activated;
            for (int i = 0; i < inventoryItemList.Count; i++) {
                Inventory.inventoryItemList[i].itemIcon = Resources.Load("RPG_inventory_icons/" + Inventory.inventoryItemList[i].itemID.ToString(), typeof(Sprite)) as Sprite;
            }
            
            if (go.activeSelf == false) {  //true일경우
                check.Visible();
                Touch.SetActive(false);
                go.SetActive(true); 
                selectedTab = 0;
                tabActivated = true; //탭 먼저 고를수 있도록
                itemActivated = false;
                ShowTab();


            }
            else { //false일경우
                StopAllCoroutines();
                go.SetActive(false); //안쓴다는 의미
                Touch.SetActive(true);
                tabActivated = false;
                itemActivated = false;
                //theOrder.Move(); //캐릭터를 움직이게
                go_OOC.SetActive(false);
                

            }
        }
    } //마우스로 가방 이미지를 클릭하는경우
    
    public void OnClickItem(Button C) {
        for (int i = 0; i < slots.Length; i++) {
            if(C.name == slots[i].name) {
                selectedItem = i;
            }
        }
        if (selectedTab == 0) {

            StartCoroutine(OKOR("사용", "취소"));
            
        }else if (selectedTab == 1) {

            StartCoroutine(OKOR("장착", "취소"));

        }


    }
    
}
