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
    // ĳ���� ������ ����Ʈ�Դϴ�.
    public static CharacterInfos datas;

    /// <summary>
    /// �����͸� ã���ϴ�.
    /// </summary>
    /// <param name="id">�ش� ������ id ��</param>
    /// <returns>ĳ���� �����͸� �����մϴ�.</returns>
    public static CharacterInfo SearchData(string id)
    {
        foreach (CharacterInfo data in datas.characterInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }
}
