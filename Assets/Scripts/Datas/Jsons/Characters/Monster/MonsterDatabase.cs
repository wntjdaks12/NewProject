using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ���� �����ͺ��̽��Դϴ�.
/// </summary>
public class MonsterDatabase : CharacterDatabase
{
    // ĳ���� ������ ����Ʈ�Դϴ�.
    public static CharacterInfos datas;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        LoadData();
    }

    // �����͸� �н��ϴ�.
    private void LoadData()
    {
        // �ش� ��ο� �ִ� ���̽� �����͸� üũ�մϴ�.
        if (!new FileInfo(Application.persistentDataPath + "Monster.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.persistentDataPath + "Monster.json");
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
                return DeepCopy(data);
        }

        return null;
    }
}
