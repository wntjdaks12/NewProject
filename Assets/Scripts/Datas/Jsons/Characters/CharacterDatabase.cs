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
    // 캐릭터 데이터 리스트입니다.
    public static CharacterInfos datas;

    /// <summary>
    /// 데이터를 찾습니다.
    /// </summary>
    /// <param name="id">해당 데이터 id 값</param>
    /// <returns>캐릭터 데이터를 리턴합니다.</returns>
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
