using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ��ܿ� ���� �����͸� �����ִ� �κ��Դϴ�.
/// </summary>
public class MonsterData : MonoBehaviour
{
    private CharacterInfo data;

    /// <summary>
    /// �����͸� �н��ϴ�.
    /// </summary>
    /// <param name="id">�ش� ���� ID</param>
    public void DataLoad(string id)
    {
        data = MonsterDatabase.SearchData(id);
    }

    public CharacterInfo Data { get => data; }
}
