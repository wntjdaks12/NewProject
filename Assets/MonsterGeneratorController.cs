using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterGeneratorController : MonoBehaviour
{
    // �������� ���� ������Ʈ Ǯ���� ����մϴ�.
    [SerializeField]
    private Pool pool;

    private void Start()
    {
        pool.DeQueue();
    }
}
