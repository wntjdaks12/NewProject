using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// �÷��̾� ������ �����Դϴ�.
/// </summary>
public class PlayerInfo
{
    /// <summary>
    /// �̵� �ӵ��Դϴ�.
    /// </summary>
    public float speed;

    public PlayerInfo(float speed)
    {
        this.speed = speed;
    }
}

/// <summary>
/// �÷��̾� �����ͺ��̽��Դϴ�.
/// </summary>
[System.Serializable]
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
        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/CharacterData.json");
        data = JsonUtility.FromJson<PlayerInfo>(dataStr);
        // ------------------------------------------------------------------------------------------------
        
        // ��ũ���ͺ� �����Ϳ� �����մϴ�. -----------------------------
        playerData.Speed = data.speed;
        // ------------------------------------------------------------
    }
}
