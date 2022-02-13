using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ����ǰ ������ �����Դϴ�.
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
/// ����ǰ ������ ����Ʈ�Դϴ�.
/// </summary>
[System.Serializable]
public class OwnerInfo
{
    [HideInInspector]
    public string id;
    public List<LootInfo> lootInfos;
}

/// <summary>
/// ����ǰ ����Ʈ�Դϴ�.
/// </summary>
public class LootInfos
{
    public List<OwnerInfo> ownerInfos;
}

/// <summary>
/// ����ǰ �����ͺ��̽��Դϴ�.
/// </summary>
public class LootDatabase : MonoBehaviour
{
    // ����ǰ ������ ����Ʈ�Դϴ�.
    private static LootInfos datas;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        LoadData();
    }

    // �����͸� �н��ϴ�.
    private void LoadData()
    {
        if (!new FileInfo(Application.persistentDataPath + "/Loot.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "/Loot.json");

        datas = JsonUtility.FromJson<LootInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // �����͸� ã���ϴ�.
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
