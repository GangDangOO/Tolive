using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    Stat asd;
    public List<Item> itemList;
    
    Text State1;
    Text State2;
    Text ATKState;
    Text DEFState;
    Text PoisonTime;
    GameObject ThisObj;
   


    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        asd = GameObject.FindObjectOfType<Stat>();
        itemList.Add(new Item(1001, "사과", "굶주림과 갈증을 해소시켜준다", Item.ItemType.Use));
        itemList.Add(new Item(1003, "고기", "굶주림을 해소시켜준다", Item.ItemType.Use));
        itemList.Add(new Item(1004, "독주머니", "전갈의 독을 사용할수 있게 해준다", Item.ItemType.Use));
        itemList.Add(new Item(1005, "불", "주위를 밝혀준다", Item.ItemType.Use));
        itemList.Add(new Item(1002, "물통", "갈증을 해소시켜준다", Item.ItemType.Use));
        itemList.Add(new Item(1006, "구운 고기", "굶주림과 체력을 크게 회복해준다.", Item.ItemType.Use));
        itemList.Add(new Item(1007, "화살", "활과 함께 사용하는 화살이다", Item.ItemType.Use)); //Arrow
        itemList.Add(new Item(1008, "짱돌", "새총과 함께 사용하는 돌멩이다", Item.ItemType.Use)); //SlingRock
        itemList.Add(new Item(1009, "신호탄", "구출할때 사용하는 신호", Item.ItemType.Use));

        itemList.Add(new Item(20001, "막대기", "나무조각으로 만든 기본 무기", Item.ItemType.Equip)); //Stick
        itemList.Add(new Item(20002, "돌도끼", "나무를 벨수있는 강한도끼", Item.ItemType.Equip)); //Axe
        itemList.Add(new Item(20003, "곡괭이", "돌을 캘수 있는 곡괭이", Item.ItemType.Equip)); //Pickax
        itemList.Add(new Item(20004, "돌칼", "돌로 만든 칼", Item.ItemType.Equip)); //Knife
        itemList.Add(new Item(20005, "창", "막대기로 이용한 창", Item.ItemType.Equip)); //Spear
        itemList.Add(new Item(20006, "활", "투박해보이지만 강력한 활", Item.ItemType.Equip)); //Bow
        itemList.Add(new Item(20007, "새총", "기본 사거리가 늘어난다", Item.ItemType.Equip)); //Slingshot
        itemList.Add(new Item(20008, "날카로운 돌칼", "돌칼 보다 더 날카롭다", Item.ItemType.Equip)); //S_Knife
        itemList.Add(new Item(20009, "날카로운 창", "창보다 더 날카롭다", Item.ItemType.Equip)); //S_Spear
        itemList.Add(new Item(20010, "횃불", "주변을 환하게 밝혀준다", Item.ItemType.Equip));//Torch

        itemList.Add(new Item(20101, "천갑옷", "천으로 만든 갑옷", Item.ItemType.Equip));
        itemList.Add(new Item(20102, "일반가죽갑옷", "일반가죽으로 만든 갑옷", Item.ItemType.Equip));        
        itemList.Add(new Item(20103, "질긴갑옷", "질긴가죽으로 만든 갑옷", Item.ItemType.Equip));
        itemList.Add(new Item(20104, "단단한갑옷", "단단한 가죽으로 만든 갑옷", Item.ItemType.Equip));

        itemList.Add(new Item(20201, "천투구", "천으로 만든 투구", Item.ItemType.Equip));
        itemList.Add(new Item(20202, "일반가죽투구", "일반가죽으로 만든 투구", Item.ItemType.Equip));        
        itemList.Add(new Item(20203, "질긴투구", "질긴가죽으로 만든 투구", Item.ItemType.Equip));
        itemList.Add(new Item(20204, "단단한투구", "단단한 가죽으로 만든 투구", Item.ItemType.Equip));

        itemList.Add(new Item(20301, "천장갑", "천으로 만든 장갑", Item.ItemType.Equip));
        itemList.Add(new Item(20302, "일반장갑", "일반가죽으로 만든 장갑", Item.ItemType.Equip));        
        itemList.Add(new Item(20303, "질긴장갑", "질긴가죽으로 만든 장갑", Item.ItemType.Equip));
        itemList.Add(new Item(20304, "단단한장갑", "단단한 가죽으로 만든 장갑", Item.ItemType.Equip));

        itemList.Add(new Item(20401, "천신발", "천으로 만든 신발", Item.ItemType.Equip));
        itemList.Add(new Item(20402, "일반가죽신발", "일반 가죽으로 만든 신발", Item.ItemType.Equip));        
        itemList.Add(new Item(20403, "질긴신발", "질긴 가죽으로 만든 신발", Item.ItemType.Equip));
        itemList.Add(new Item(20404, "단단한신발", "단단한 가죽으로 만든 신발", Item.ItemType.Equip));



        itemList.Add(new Item(3001, "돌", "무기를 만드는 재료", Item.ItemType.ETC));
        itemList.Add(new Item(3002, "악어의눈물", "신호탄의 재료", Item.ItemType.ETC));
        itemList.Add(new Item(3003, "나무조각", "나무에서 얻은 조각", Item.ItemType.ETC));
        itemList.Add(new Item(3004, "줄기", "나무에서 얻은 줄기", Item.ItemType.ETC));
        itemList.Add(new Item(3005, "끈", "줄기를 엮어서 만들수 있다", Item.ItemType.ETC));
        itemList.Add(new Item(3006, "잎", "나무에서 얻은 잎사귀", Item.ItemType.ETC));
        itemList.Add(new Item(3007, "천", "잎을 사용하여 만들수 있다", Item.ItemType.ETC));
        itemList.Add(new Item(3008, "독", "전갈의 독", Item.ItemType.ETC));
        itemList.Add(new Item(3009, "일반 가죽", "방어구를 만들수 있는 재료", Item.ItemType.ETC));
        itemList.Add(new Item(3010, "질긴 가죽", "일반 가죽보다 더 질긴 방어구를 만들수 있다", Item.ItemType.ETC));
        itemList.Add(new Item(3011, "단단한 가죽", "단단한 방어구를 만들수 있다", Item.ItemType.ETC));
        itemList.Add(new Item(3012, "날카로운 이빨", "무기를 날카롭게 만들때 쓰임", Item.ItemType.ETC));
        itemList.Add(new Item(3013, "곰의 비료", "신호탄의 재료", Item.ItemType.ETC));
        itemList.Add(new Item(3014, "상어 지느러미", "신호탄의 재료", Item.ItemType.ETC));
    }

    public void UseItem(int _itemID) {
        switch (_itemID) {
            case 1001:
                Debug.Log("사과를 사용");
                asd.x += 20;
                asd.y += 10;
                asd.health += 10;
                if (asd.x >= 100) {
                    asd.x = 100;
                }
                if (asd.y >= 100) {
                    asd.y = 100;
                }
                if (asd.health >= 100) {
                    asd.health = 100;
                }
                break;
            case 1002:
                Debug.Log("물을 사용");
                asd.y += 30;
                if (asd.y >= 100) {
                    asd.y = 100;
                }
                break;
            case 1003:
                Debug.Log("고기를 사용");
                asd.x += 40;
                if (asd.x >= 100) {
                    asd.x = 100;
                }
                asd.health += 20;
                if(asd.health >= 100) {
                    asd.health = 100;
                }
                break;
            case 1004:
                Debug.Log("독을 사용");
                asd.PoisonEffect.SetActive(true);
                StartCoroutine(PoisonEffectTime(asd.time2));
                break;
            case 1005:
                Debug.Log("불을 사용");
                break;
            case 1006:
                Debug.Log("구운 고기를 사용");
                asd.x += 70;
                if (asd.x >= 100) {
                    asd.x = 100;
                }
                asd.health += 40;
                if (asd.health >= 100) {
                    asd.health = 100;
                }
                break;
        }

    }
    IEnumerator PoisonEffectTime(float sec)
    {
        asd.PlayerATK += 10;
        while (true)
        {
            if (asd.PoisonEffect.activeSelf == true)
            {
                yield return new WaitForSeconds(sec);
                if (Stat.instance.z <= 10 && Stat.instance.z >= 0)
                {
                    Stat.instance.PoisonTime.text = Stat.instance.z.ToString();
                    Stat.instance.z -= 1;
                    
                    
                }
                else if (Stat.instance.z < 0)
                {
                    Stat.instance.PoisonEffect.SetActive(false);
                    asd.PlayerATK -= 5; 
                }
                
            }
            
        yield return null;
        }

    }
    

    private void Awake() {
        ThisObj = GameObject.Find("CharInfo");
        State1 = GameObject.Find("Stats01_#").GetComponent<Text>();//배고픔
        State2 = GameObject.Find("Stats02_#").GetComponent<Text>();//목마름
        ATKState = GameObject.Find("Melee_#").GetComponent<Text>();//공격력
        DEFState = GameObject.Find("Ranged_#").GetComponent<Text>();//방어력
    }

}
