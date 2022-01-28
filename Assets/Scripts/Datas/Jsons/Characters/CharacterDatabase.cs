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
    public string image;
    public string weaponId;
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

        characterInfo.id = data.id;
        characterInfo.keyName = data.keyName;
        characterInfo.speed = data.speed;
        characterInfo.hp = data.hp;
        characterInfo.maxHp = data.maxHp;
        characterInfo.lv = data.lv;
        characterInfo.image = data.image;
        characterInfo.weaponId = data.weaponId;
   
        return characterInfo;
    }
}
