using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ǯ���� ������Ʈ �����Դϴ�.
/// </summary>
public class Pool : MonoBehaviour
{
    // Ǯ���� ������Ʈ�� FIFO ������ ť�� ����ϴ�.
    private Queue<GameObject> objectPool;

    /// <summary>
    /// Ǯ���� ����Դϴ�.
    /// </summary>
    public GameObject target;

    /// <summary>
    /// Ǯ���� �����Դϴ�.
    /// </summary>
    public int poolCount;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    /// <summary>
    /// Ǯ���� �ʱ�ȭ ��ŵ�ϴ�.
    /// </summary>
    public void Init()
    {
        if (!target)
            return;

        for (int i = 0; i < poolCount; i++)
        {
            // Ǯ���� ������Ʈ�� �����մϴ�.
            var target = Instantiate(this.target);

            // ����� �ش� ������Ʈ�� ������ ���� ���� ��� Ǯ���� ���� �ʽ��ϴ�.
            if (!target.GetComponent<PoolableObject>())
            {
                Destroy(target);

                return;
            }

            // ��������� �ڽ��� �ν��Ͻ��� �Ѱ��ݴϴ�.
            target.GetComponent<PoolableObject>().Pool = this;

            // ����� ��Ȱ��ȭ ��ŵ�ϴ�.
            EnQueue(target);
        }
    }

    /// <summary>
    /// Ǯ�� ����� Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <returns>Ȱ��ȭ�� ����� �����մϴ�.</returns>
    public GameObject DeQueue()
    {
        if (objectPool.Count == 0)
            return null;

        var obj = objectPool.Dequeue();
        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Ǯ�� ����� ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="target">Ǯ�� ���</param>
    public void EnQueue(GameObject target)
    {
        target.SetActive(false);

        objectPool.Enqueue(target);
    }

    /// <summary>
    /// ���� ������Ʈ ť ���¸� �����մϴ�.
    /// </summary>
    public Queue<GameObject> ObjectPool { get { return objectPool; } }
}
