using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 데이터 정보입니다.
/// </summary>
[System.Serializable]
public class CharacterInfo
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string keyName;
    public float speed;
    public int hp;
    public int maxHp;
    public int lv;
    public WeaponInfo weaponInfo;
}

/// <summary>
/// 캐릭터 데이터 리스트입니다.
/// </summary>
public class CharacterInfos
{
    public List<CharacterInfo> characterInfos;
}

/// <summary>
/// 캐릭터 데이터베이스입니다.
/// </summary>
public class CharacterDatabase : MonoBehaviour
{
    protected static CharacterInfo DeepCopy(CharacterInfo data)
    {
        CharacterInfo characterInfo = new CharacterInfo();

        characterInfo.hp = data.hp;
        characterInfo.id = data.id;
        characterInfo.keyName = data.keyName;
        characterInfo.maxHp = data.maxHp;
        characterInfo.speed = data.speed;
        characterInfo.lv = data.lv;
        characterInfo.weaponInfo = WeaponDatabase.DeepCopy(data.weaponInfo);
   
        return characterInfo;
    }
}
