using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��� ����ü�� �ֻ����Դϴ�.
/// </summary>
public class Projectile : MonoBehaviour
{
    // ���� �����Դϴ�.
    private Rigidbody rigid;

    // ����ü�� ����� �����ڿ� ���ϴ� ����Դϴ�.
    private GameObject owner, target;

    // Ǯ���� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    // �浹 �� �̺�Ʈ�Դϴ�.
    public UnityEvent<Collider> triggerEvent;

    // ����ü�� ���� �������Դϴ�.
    protected ProjectileAttackBehaviour projectileBehaviour;

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

            Move(speed);
        }
    }

    public void Move(float speed)
    {
        // ������ �����մϴ�.
        rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null)
            // �浹 ����� �����ϰ� �ִ� ������� �Ǵ��մϴ�.
            if (other.tag != target.tag)
                return;

        // ��󿡰� �������� �����ϴ�.
        Hit(other);

        // Ǯ�� ��ü�̹Ƿ� ��Ȱ��ȭ��ŵ�ϴ�.
        triggerEvent?.Invoke(other);

        // �����մϴ�. (Ǯ�� ��Ȱ��ȭ)
        // Destroy();
        target = null;
    }

    // �����մϴ�. (Ǯ�� ��Ȱ��ȭ)
    public void Destroy()
    {
        // Ǯ�� ��ü�̹Ƿ� ��Ȱ��ȭ��ŵ�ϴ�. ---------------------------------------------------
        poolableObject?.EnQueue();
        // ---------------------------------------------------------------------
    }

    // �������� �����ϴ�.
    private void Hit(Collider other)
    {
        // �ｺ �������̽��� ������ ����� ��츸 �����մϴ�.
        other.GetComponent<IDamageable>()?.Damage(owner, 1);
    }

    /// <summary>
    /// ����ü�� ����� �������Դϴ�.
    /// </summary>
    public GameObject Owner { set => owner = value; }

    /// <summary>
    /// ����ü�� ���ϴ� ����Դϴ�.
    /// </summary>
    public GameObject Target { get => target; set => target = value; }
}
