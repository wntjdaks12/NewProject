using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ���� ������ �����Դϴ�.
/// </summary>
[System.Serializable]
public class WeaponInfo
{
    public string id;
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
/// ���� ������ ����Ʈ�Դϴ�.
/// </summary>
public class WeaponInfos
{
    public List<WeaponInfo> weaponInfos;
}

/// <summary>
/// ���� �����ͺ��̽��Դϴ�.
/// </summary>
public class WeaponDatabase : MonoBehaviour
{
    // ���� ������ ����Ʈ�Դϴ�.
    private static WeaponInfos datas;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        LoadData();
    }

    // �����͸� �н��ϴ�.
    private void LoadData()
    {
        // �ش� ��ο� �ִ� ���̽� �����͸� üũ�մϴ�.
        if (!new FileInfo(Application.dataPath + "/Datas/Jsons/Weapons/Weapons.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/Weapons/Weapons.json");
        datas = JsonUtility.FromJson<WeaponInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // �����͸� ã���ϴ�.
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
