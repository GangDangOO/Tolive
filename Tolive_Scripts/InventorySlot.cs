using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text itemName_Text;
    public Text itemCount_Text;
    public GameObject selected_Item;

    //아이템 갯수
    public void Additem(Item _item) {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;
        //소모품아이템 갯수 증가
        if(Item.ItemType.Use == _item.itemType) {
            if(_item.itemCount > 0) {
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            }else {
                itemCount_Text.text = "";
            }
        }
        //재료 아이템 갯수 증가
        if (Item.ItemType.ETC == _item.itemType) {
            if (_item.itemCount > 0) {
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            }
            else {
                itemCount_Text.text = "";
            }
        }
    }

    public void RemoveItem() {
        itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
