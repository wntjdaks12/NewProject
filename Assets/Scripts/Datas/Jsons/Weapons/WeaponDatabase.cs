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
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string keyName;
    [HideInInspector]
    public string basicAttackImg;
    public float cooldownTime;
    public float range;

    public WeaponInfo(string id, string keyName, string basicAttackImg, float cooldownTime,float range)
    {
        this.id = id;
        this.keyName = keyName;
        this.basicAttackImg = basicAttackImg;
        this.cooldownTime = cooldownTime;
        this.range = range;
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
        if (!new FileInfo(Application.persistentDataPath + "/Weapons.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "/Weapons.json");
        datas = JsonUtility.FromJson<WeaponInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    // �����͸� ã���ϴ�.
    public static WeaponInfo SearchData(string id)
    {
        if (datas == null)
            return null;

        foreach (WeaponInfo data in datas.weaponInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }

    public static WeaponInfo DeepCopy(WeaponInfo data)
    {
        WeaponInfo weaponInfo = new WeaponInfo(
            data.id,
            data.keyName,
            data.basicAttackImg,
            data.cooldownTime,
            data.range
        );
        return weaponInfo;
    }
}
