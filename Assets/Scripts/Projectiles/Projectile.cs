using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProjectileInfo
{
    public int speed;
}

/// <summary>
/// 모든 투사체의 최상위입니다.
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileInfo data;

    // 물리 제어입니다.
    private Rigidbody rigid;

    // 투사체를 사용한 소유자와 향하는 대상입니다.
    private GameObject owner, target;

    // 풀링할 오브젝트입니다.
    private PoolableObject poolableObject;

    // 충돌 시 이벤트입니다.
    public UnityEvent<GameObject> triggerEvent;

    // 투사체의 공격 행위자입니다.
    protected ProjectileAttackBehaviour projectileAttackBehaviour;

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

            Move();
        }
        else
            TriggerEventHandler(target);
    }

    public void Move()
    {
        // 앞으로 직진합니다.
        rigid.velocity = transform.forward * data.speed * Time.deltaTime;
    }

    /// <summary>
    /// 충돌 이벤트핸들러입니다.
    /// </summary>
    /// <param name="other">충돌 대상</param>
    public void TriggerEventHandler(GameObject other)
    {        
        Hit(other);

        triggerEvent?.Invoke(other);

        target = null;
    }

    /// <summary>
    /// 풀링 개체이므로 비활성화시킵니다.
    /// </summary>
    public void Disable() => poolableObject?.EnQueue();

    /// <summary>
    /// 데미지를 입힙니다.
    /// </summary>
    /// <param name="other"></param>
    private void Hit(GameObject other) => other.GetComponent<IDamageable>()?.Damage(owner, 1);

    /// <summary>
    /// 투사체를 사용한 소유자입니다.
    /// </summary>
    public GameObject Owner { set => owner = value; }

    /// <summary>
    /// 투사체가 향하는 대상입니다.
    /// </summary>
    public GameObject Target { get => target; set => target = value; }
}
