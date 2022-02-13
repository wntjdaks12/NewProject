using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 전리품 데이터 정보입니다.
/// </summary>
[System.Serializable]
public class LootInfo
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string keyName;
    public int probability;

    public int amount;
}

/// <summary>
/// 전리품 소유자 리스트입니다.
/// </summary>
[System.Serializable]
public class OwnerInfo
{
    [HideInInspector]
    public string id;
    public List<LootInfo> lootInfos;
}

/// <summary>
/// 전리품 리스트입니다.
/// </summary>
public class LootInfos
{
    public List<OwnerInfo> ownerInfos;
}

/// <summary>
/// 전리품 데이터베이스입니다.
/// </summary>
public class LootDatabase : MonoBehaviour
{
    // 전리품 데이터 리스트입니다.
    private static LootInfos datas;

    private void Start()
    {
        // 데이터를 읽습니다.
        LoadData();
    }

    // 데이터를 읽습니다.
    private void LoadData()
    {
        if (!new FileInfo(Application.persistentDataPath + "/Loot.json").Exists)
            return;

        // 해당 경로의 제이슨 데이터를 읽고 오브젝트형으로 변환합니다. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "/Loot.json");

        datas = JsonUtility.FromJson<LootInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // 데이터를 찾습니다.
    public static OwnerInfo SearchData(string id)
    {
        if (datas == null)
            return null;

        foreach (OwnerInfo data in datas.ownerInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }
}
