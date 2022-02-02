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
/// ��� ����ü�� �ֻ����Դϴ�.
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected ProjectileInfo data;

    // ���� �����Դϴ�.
    private Rigidbody rigid;

    // ����ü�� ����� �����ڿ� ���ϴ� ����Դϴ�.
    private GameObject owner, target;

    // Ǯ���� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    // �浹 �� �̺�Ʈ�Դϴ�.
    public UnityEvent<GameObject> triggerEvent;

    // ����ü�� ���� �������Դϴ�.
    protected ProjectileAttackBehaviour projectileAttackBehaviour;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        poolableObject = GetComponent<PoolableObject>();
    }

    /// <summary>
    /// ����� �����Ͽ� �����Դϴ�.
    /// </summary>
    /// <param name="speed">�̵� �ӵ�</param>
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
        // ������ �����մϴ�.
        rigid.velocity = transform.forward * data.speed * Time.deltaTime;
    }

    /// <summary>
    /// �浹 �̺�Ʈ�ڵ鷯�Դϴ�.
    /// </summary>
    /// <param name="other">�浹 ���</param>
    public void TriggerEventHandler(GameObject other)
    {        
        Hit(other);

        triggerEvent?.Invoke(other);

        target = null;
    }

    /// <summary>
    /// Ǯ�� ��ü�̹Ƿ� ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Disable() => poolableObject?.EnQueue();

    /// <summary>
    /// �������� �����ϴ�.
    /// </summary>
    /// <param name="other"></param>
    private void Hit(GameObject other) => other.GetComponent<IDamageable>()?.Damage(owner, 1);

    /// <summary>
    /// ����ü�� ����� �������Դϴ�.
    /// </summary>
    public GameObject Owner { set => owner = value; }

    /// <summary>
    /// ����ü�� ���ϴ� ����Դϴ�.
    /// </summary>
    public GameObject Target { get => target; set => target = value; }
}
