using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 데이터 정보입니다.
/// </summary>
[System.Serializable]
public class CharacterInfo
{
    public string id;
    public string keyName;
    public float speed;
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

    // 데이터를 찾습니다.
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
