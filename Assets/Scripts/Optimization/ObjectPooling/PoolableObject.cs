using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ǯ���� ������Ʈ�Դϴ�.
/// </summary>
public class PoolableObject : MonoBehaviour
{
    // Ǯ ����Դϴ�.
    private Pool pool;

    /// <summary>
    /// ������Ʈ�� ��Ȱ��ȭ ��ŵ�ϴ�.
    /// </summary>
    public void EnQueue()
    {
        // Ǯ ����� ������ ��� ������Ʈ�� ��Ȱ��ȭ ��Ű�� �ƴ� ��� �����մϴ�.
        if (pool != null)
            pool.EnQueue(gameObject);

    }
    // Ǯ ����Դϴ�.
    public Pool Pool { set { pool = value; } }
}
