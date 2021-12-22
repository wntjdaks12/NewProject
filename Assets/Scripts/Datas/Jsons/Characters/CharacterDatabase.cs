using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ���� ������ �����Դϴ�.
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
/// ĳ���� ������ ����Ʈ�Դϴ�.
/// </summary>
public class CharacterInfos
{
    public List<CharacterInfo> characterInfos;
}

/// <summary>
/// ĳ���� �����ͺ��̽��Դϴ�.
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
