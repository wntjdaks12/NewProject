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
    public CharacterInfo characterInfo;

    public PlayerInfo(CharacterInfo characterInfo)
    {
        this.characterInfo = characterInfo;
    }
}

/// <summary>
/// �÷��̾� �����ͺ��̽��Դϴ�.
/// </summary>
public class PlayerDatabase : CharacterDatabase
{
    // ĳ���� ������ ����Ʈ�Դϴ�.
    public static CharacterInfos datas;


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
        // �ش� ��ο� �ִ� ���̽� �����͸� üũ�մϴ�.
        if (!new FileInfo(Application.persistentDataPath + "Player.json").Exists)
            return;
            
        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "Player.json");
        datas = JsonUtility.FromJson<CharacterInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// �����͸� ã���ϴ�.
    /// </summary>
    /// <param name="id">�ش� ������ id ��</param>
    /// <returns>ĳ���� �����͸� �����մϴ�.</returns>
    public static CharacterInfo SearchData(string id)
    {
        if (datas == null)
            return null;

        foreach (CharacterInfo data in datas.characterInfos)
        {
            if (id == data.id)
                return data;
        }

        return null;
    }
}
