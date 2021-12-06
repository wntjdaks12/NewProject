using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 풀링할 오브젝트 집합체입니다.
/// </summary>
public class Pool : MonoBehaviour
{
    // 풀링할 오브젝트 리스트입니다.
    private Queue<GameObject> objectPool;

    /// <summary>
    /// 풀링할 대상입니다.
    /// </summary>
    public GameObject target;

    /// <summary>
    /// 풀링할 개수입니다.
    /// </summary>
    public int poolCount;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    /// <summary>
    /// 풀링을 초기화 시킵니다.
    /// </summary>
    public void OnEnable()
    {
        if (!target)
            return;

        // 풀링할 개수만큼 풀링할 오브젝트 리스트에 담습니다.
        for (int i = 0; i < poolCount; i++)
        {
            // 풀링할 오브젝트를 생성합니다.
            var target = Instantiate(this.target, transform);

            // 대상이 해당 컴포넌트를 소유를 하지 않을 경우 풀링을 하지 않습니다.
            if (!target.GetComponent<PoolableObject>())
            {
                Destroy(target);

                return;
            }

            // 연관관계로 자신의 인스턴스를 넘겨줍니다.
            target.GetComponent<PoolableObject>().Pool = this;

            // 대상을 비활성화 시킵니다.
            EnQueue(target);
        }
    }

    /// <summary>
    /// 풀링 대상을 활성화시킵니다.
    /// </summary>
    /// <returns>활성화된 대상을 리턴합니다.</returns>
    public GameObject DeQueue()
    {
        //  풀링 오브젝트 리스트에 풀링 대상을 빼고 활성화 시킵니다. ----------
        if (objectPool.Count == 0)
            return null;

        var obj = objectPool.Dequeue();
        obj.SetActive(true);
        // ----------------------------------------------------------------

        return obj;
    }

    /// <summary>
    /// 풀링 대상을 비활성화시킵니다.
    /// </summary>
    /// <param name="target">풀링 대상</param>
    public void EnQueue(GameObject target)
    {
        // 풀링 대상을 비활성화 시키고 풀링 오브젝트 리스트에 담습니다. ---------
        target.SetActive(false);

        objectPool.Enqueue(target);
        // -------------------------------------------------------------------
    }

    /// <summary>
    /// 풀링할 오브젝트 리스트입니다.
    /// </summary>
    public Queue<GameObject> ObjectPool { get { return objectPool; } }
}
