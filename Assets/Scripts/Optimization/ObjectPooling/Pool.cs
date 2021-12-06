using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ǯ���� ������Ʈ ����ü�Դϴ�.
/// </summary>
public class Pool : MonoBehaviour
{
    // Ǯ���� ������Ʈ ����Ʈ�Դϴ�.
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
    public void OnEnable()
    {
        if (!target)
            return;

        // Ǯ���� ������ŭ Ǯ���� ������Ʈ ����Ʈ�� ����ϴ�.
        for (int i = 0; i < poolCount; i++)
        {
            // Ǯ���� ������Ʈ�� �����մϴ�.
            var target = Instantiate(this.target, transform);

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
        //  Ǯ�� ������Ʈ ����Ʈ�� Ǯ�� ����� ���� Ȱ��ȭ ��ŵ�ϴ�. ----------
        if (objectPool.Count == 0)
            return null;

        var obj = objectPool.Dequeue();
        obj.SetActive(true);
        // ----------------------------------------------------------------

        return obj;
    }

    /// <summary>
    /// Ǯ�� ����� ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="target">Ǯ�� ���</param>
    public void EnQueue(GameObject target)
    {
        // Ǯ�� ����� ��Ȱ��ȭ ��Ű�� Ǯ�� ������Ʈ ����Ʈ�� ����ϴ�. ---------
        target.SetActive(false);

        objectPool.Enqueue(target);
        // -------------------------------------------------------------------
    }

    /// <summary>
    /// Ǯ���� ������Ʈ ����Ʈ�Դϴ�.
    /// </summary>
    public Queue<GameObject> ObjectPool { get { return objectPool; } }
}
