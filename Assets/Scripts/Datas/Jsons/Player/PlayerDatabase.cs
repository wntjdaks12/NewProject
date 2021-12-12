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
        datas = JsonUtility.FromJson<CharacterInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }
}
