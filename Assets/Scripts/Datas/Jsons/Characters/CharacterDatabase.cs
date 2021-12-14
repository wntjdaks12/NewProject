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

}