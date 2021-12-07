using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 투사체의 최상위입니다.
/// </summary>
public class Projectile : MonoBehaviour
{
    // 물리 제어입니다.
    private Rigidbody rigid;

    /// <summary>
    /// 투사체가 향하는 대상입니다.
    /// </summary>
    public GameObject target;

    // 풀링할 오브젝트입니다.
    private PoolableObject poolableObject;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();

        poolableObject = GetComponent<PoolableObject>() ?? GetComponent<PoolableObject>();
    }

    private void FixedUpdate()
    {
        Trace(500);
    }

    /// <summary>
    /// 대상을 추적하여 움직입니다.
    /// </summary>
    /// <param name="speed">이동 속도</param>
    public void Trace(float speed)
    {
        if (!target || !rigid)
            return;

        // 대상을 바라봅니다.
        transform.LookAt(target.transform);

        // 앞으로 직진합니다.
        rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != target.tag)
            return;

        // 충돌 대상이 추적하는 대상과 같으면 인큐를 하여 비활성화시킵니다. --------
        target = null;

        poolableObject?.EnQueue();
        // ---------------------------------------------------------------------
    }
}
