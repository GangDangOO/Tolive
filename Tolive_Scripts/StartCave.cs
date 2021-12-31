using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class StartCave : MonoBehaviour
{
    Stat Data;
    Equipment Equ;
    
    private void Awake()
    {
        Equ = GameObject.FindObjectOfType<Equipment>();
        Title.CheckLoad = true;
    }
    private void Start()
    {
        // 인벤토리
        string Itemstring = File.ReadAllText(Application.persistentDataPath + "/ItemData.json");
        JsonData ItemData = JsonMapper.ToObject(Itemstring);
        string Equstring = File.ReadAllText(Application.persistentDataPath + "/EquData.json");
        JsonData EquData = JsonMapper.ToObject(Equstring);
        Inventory.inventoryItemList.Clear();
        for (int i = 0; i < ItemData.Count; i++)
        {
            Inventory.inventoryItemList.Add(new Item(
                int.Parse(ItemData[i]["itemID"].ToString()),
                ItemData[i]["itemName"].ToString(),
                ItemData[i]["itemDescription"].ToString(),
                (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), ItemData[i]["itemType"].ToString()),
                int.Parse(ItemData[i]["itemCount"].ToString())
            ));
        }
        for (int i = 0; i < Equ.equipItemList.Length; i++)
        {
            Equ.equipItemList[i].itemID = (int)EquData[i]["itemID"];
            Equ.equipItemList[i].itemName = EquData[i]["itemName"].ToString();
            Equ.equipItemList[i].itemDescription = EquData[i]["itemDescription"].ToString();
            Equ.equipItemList[i].itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), EquData[i]["itemType"].ToString());
            Equ.equipItemList[i].itemCount = (int)EquData[i]["itemCount"];
            Equ.equipItemList[i].itemIcon = Resources.Load("RPG_inventory_icons/" + Equ.equipItemList[i].itemID.ToString(), typeof(Sprite)) as Sprite;
            Equ.equipItemList[i].itemDuration = (int)EquData[i]["itemDuration"];
        }
        // 착용정보
        Inventory.op.SetActive(false);
        Inventory.op = GameObject.Find("Hand.R").transform.Find(PlayerPrefs.GetString("WeaponeSave")).gameObject;
        Inventory.op.SetActive(true);
        // 스텟
        string Statstring = File.ReadAllText(Application.persistentDataPath + "/Stat.json");
        JsonData StatData = JsonMapper.ToObject(Statstring);
        Data = GameObject.FindWithTag("Player").GetComponent<Stat>();
        Data.health = (int)StatData["HPSave"];
        Data.x = (int)StatData["XSave"];
        Data.y = (int)StatData["YSave"];
        Data.PlayerATK = (int)StatData["ATKSave"];
        Data.PlayerDEF = (int)StatData["DEFSave"];
    }
}
