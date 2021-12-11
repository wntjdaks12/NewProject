using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// �÷��̾� ������ �����Դϴ�.
/// </summary>
[System.Serializable]
public class PlayerInfo
{
    public float speed;
    public WeaponInfo weaponInfo;

    public PlayerInfo(float speed, WeaponInfo weaponInfo)
    {
        this.speed = speed;
        this.weaponInfo = weaponInfo;
    }
}

/// <summary>
/// �÷��̾� �����ͺ��̽��Դϴ�.
/// </summary>
public class PlayerDatabase : MonoBehaviour
{
    // �÷��̾� �������Դϴ�.
    private PlayerInfo data;

    // �÷��̾� ��ũ���ͺ� �������Դϴ�.
    [SerializeField]
    private PlayerData playerData;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        LoadData();
    }

    // �����͸� �н��ϴ�.
    private void LoadData()
    {
        // // �ش� ��ο� �ִ� ���̽� �����͸� üũ�մϴ�.
        if (!new FileInfo(Application.dataPath + "/Datas/Jsons/Player/Player.json").Exists)
            return;
            
        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/Player/Player.json");
        data = JsonUtility.FromJson<PlayerInfo>(dataStr);
        // ------------------------------------------------------------------------------------------------

        // ��ũ���ͺ� �����Ϳ� �����մϴ�. -----------------------------
        playerData.Speed = data.speed;
        // ------------------------------------------------------------
    }
}
