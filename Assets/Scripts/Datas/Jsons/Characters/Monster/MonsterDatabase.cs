using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ���� �����ͺ��̽��Դϴ�.
/// </summary>
public class MonsterDatabase : CharacterDatabase
{
    private void Start()
    {
        // �����͸� �н��ϴ�.
        LoadData();
    }

    // �����͸� �н��ϴ�.
    private void LoadData()
    {
        // // �ش� ��ο� �ִ� ���̽� �����͸� üũ�մϴ�.
        if (!new FileInfo(Application.dataPath + "/Datas/Jsons/Character/Monster/Monster.json").Exists)
            return;

        // �ش� ����� ���̽� �����͸� �а� ������Ʈ������ ��ȯ�մϴ�. ---------------------------------------
        var dataStr = File.ReadAllText(Application.dataPath + "/Datas/Jsons/Character/Monster/Monster.json");
        datas = JsonUtility.FromJson<CharacterInfos>(dataStr);
        // ------------------------------------------------------------------------------------------------
    }
}
