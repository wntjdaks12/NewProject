using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterController : MonoBehaviour
{
    /// <summary>
    /// �ش� ���� ����Դϴ�.
    /// </summary>
    public Monster target;

    // �ش� ����� ������ ���Դϴ�.
    [SerializeField]
    private CharacterInfo data;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        DataLoad();
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        data = MonsterDatabase.SearchData(target.Id);
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
    }

    private void FixedUpdate()
    {
        // �ش� ����� �����մϴ�.
        Control();
    }
}
