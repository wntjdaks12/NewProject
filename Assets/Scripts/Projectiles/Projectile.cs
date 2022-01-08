using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 모든 투사체의 최상위입니다.
/// </summary>
public class Projectile : MonoBehaviour
{
    // 물리 제어입니다.
    private Rigidbody rigid;

    // 투사체를 사용한 소유자와 향하는 대상입니다.
    private GameObject owner, target;

    // 풀링할 오브젝트입니다.
    private PoolableObject poolableObject;

    // 충돌 시 이벤트입니다.
    public UnityEvent<Collider> triggerEvent;

    // 투사체의 공격 행위자입니다.
    protected ProjectileAttackBehaviour projectileBehaviour;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        poolableObject = GetComponent<PoolableObject>();
    }

    /// <summary>
    /// 대상을 추적하여 움직입니다.
    /// </summary>
    /// <param name="speed">이동 속도</param>
    public void Trace(float speed)
    {
        if (!target || !rigid) return;

        if ((target.transform.position - transform.position).sqrMagnitude > 0.1f)
        {
            transform.LookAt(target.transform);

            Move(speed);
        }
    }

    public void Move(float speed)
    {
        // 앞으로 직진합니다.
        rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null)
            // 충돌 대상이 추적하고 있는 대상인지 판단합니다.
            if (other.tag != target.tag)
                return;

        // 대상에게 데미지를 입힙니다.
        Hit(other);

        // 풀링 개체이므로 비활성화시킵니다.
        triggerEvent?.Invoke(other);

        // 삭제합니다. (풀링 비활성화)
        // Destroy();
        target = null;
    }

    // 삭제합니다. (풀링 비활성화)
    public void Destroy()
    {
        // 풀링 개체이므로 비활성화시킵니다. ---------------------------------------------------
        poolableObject?.EnQueue();
        // ---------------------------------------------------------------------
    }

    // 데미지를 입힙니다.
    private void Hit(Collider other)
    {
        // 헬스 인터페이스가 구현된 대상일 경우만 적용합니다.
        other.GetComponent<IDamageable>()?.Damage(owner, 1);
    }

    /// <summary>
    /// 투사체를 사용한 소유자입니다.
    /// </summary>
    public GameObject Owner { set => owner = value; }

    /// <summary>
    /// 투사체가 향하는 대상입니다.
    /// </summary>
    public GameObject Target { get => target; set => target = value; }
}
