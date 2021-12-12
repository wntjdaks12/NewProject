using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 무기 데이터 정보입니다.
/// </summary>
[System.Serializable]
public class WeaponInfo
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string keyName;
    public float cooldownTime;

    public WeaponInfo(string id, string keyName, float cooldownTime)
    {
        this.id = id;
        this.keyName = keyName;
        this.cooldownTime = cooldownTime;
    }
}

/// <summary>
/// 무기 데이터 리스트입니다.
/// </summary>
public class WeaponInfos
{
    public List<WeaponInfo> weaponInfos;
}

/// <summary>
/// 무기 데이터베이스입니다.
/// </summary>
public class WeaponDatabase : MonoBehaviour
{
    // 무기 데이터 리스트입니다.
    private static WeaponInfos datas;

    private void Start()
    {
        // 데이터를 읽습니다.
        LoadData();
    }

    // 데이터를 읽습니다.
    private void LoadData()
    {
        // 해당 경로에 있는 제이슨 데이터를 체크합니다.
        if (!new FileInfo(Application.dataPath + "/Datas/Jsons/Weapons/Weapons.json").Exists)
            return;

        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/Weapons/Weapons.json");
        datas = JsonUtility.FromJson<WeaponInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // 데이터를 찾습니다.
    public static WeaponInfo SearchData(string id)
    {
        foreach (WeaponInfo data in datas.weaponInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }
}
