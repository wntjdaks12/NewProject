using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBarModel : IObjectHeadBarModel
{
    public PlayerData playerData;

    public PlayerData PlayerData { set => playerData = value; }

    public int getHp() => playerData == null ? 0 :
        playerData.CharacterInfo == null ? 0 : playerData.CharacterInfo.hp;

    public int getLv() => playerData == null ? 0 :
        playerData.CharacterInfo == null ? 0 : playerData.CharacterInfo.lv;

    public int getMaaxHp() => playerData == null ? 0 :
        playerData.CharacterInfo == null ? 0 : playerData.CharacterInfo.maxHp;
}
