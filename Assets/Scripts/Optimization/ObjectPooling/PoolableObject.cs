using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 풀링할 오브젝트입니다.
/// </summary>
public class PoolableObject : MonoBehaviour
{
    // 풀 대상입니다.
    private Pool pool;

    /// <summary>
    /// 오브젝트를 비활성화 시킵니다.
    /// </summary>
    public void EnQueue()
    {
        // 풀 대상이 존재할 경우 오브젝트를 비활성화 시키며 아닐 경우 삭제합니다.
        if (pool != null)
            pool.EnQueue(gameObject);

    }
    // 풀 대상입니다.
    public Pool Pool { set { pool = value; } }
}
