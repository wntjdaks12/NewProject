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
    public string id;
    public int probability;
}

/// <summary>
/// ����ǰ ������ ����Ʈ�Դϴ�.
/// </summary>
[System.Serializable]
public class OwnerInfo
{
    public string id;
    public List<LootInfo> lootInfos;
}

/// <summary>
/// ����ǰ ����Ʈ�Դϴ�.
/// </summary>
[System.Serializable]
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
        if (!new FileInfo(Application.persistentDataPath + "Loot.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "Loot.json");
        datas = JsonUtility.FromJson<LootInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // �����͸� ã���ϴ�.
    public static List<OwnerInfo> SearchData(string id)
    {
        if (datas == null)
            return null;

        for (int i = 0; i < datas.ownerInfos.Count; i++)
        {
            if (id == datas.ownerInfos[i].id)
                return datas.ownerInfos;
        }

        return null;
    }
}
