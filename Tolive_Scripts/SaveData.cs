using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string WeaponeSave;
    public int HPSave;
    public int XSave;
    public int YSave;
    public int ATKSave;
    public int DEFSave;

    public SaveData(string _Weapone, int _PlayerHP, int _PlayerX, int _PlayerY, int _PlayerATK, int _PlayerDEF)
    {
        WeaponeSave = _Weapone;
        HPSave = _PlayerHP;
        XSave = _PlayerX;
        YSave = _PlayerY;
        ATKSave = _PlayerATK;
        DEFSave = _PlayerDEF;
    }
}
