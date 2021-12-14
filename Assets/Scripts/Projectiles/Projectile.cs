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

    /// <summary>
    /// ����ü�� ���ϴ� ����Դϴ�.
    /// </summary>
    public GameObject target;

    // Ǯ���� ������Ʈ�Դϴ�.
    private PoolableObject poolableObject;

    /// <summary>
    /// �浹 �� �̺�Ʈ�Դϴ�.
    /// </summary>
    public UnityEvent<Collider> triggerEvent;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();

        poolableObject = GetComponent<PoolableObject>() ?? GetComponent<PoolableObject>();
    }

    private void FixedUpdate()
    {
        Trace(1500);
    }

    /// <summary>
    /// ����� �����Ͽ� �����Դϴ�.
    /// </summary>
    /// <param name="speed">�̵� �ӵ�</param>
    public void Trace(float speed)
    {
        if (!target || !rigid)
            return;

        // ����� �ٶ󺾴ϴ�.
        transform.LookAt(target.transform);

        // ������ �����մϴ�.
        rigid.velocity = transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != target.tag)
            return;

        // ��󿡰� �������� �����ϴ�.
        Hit(other);

        // �浹 ����� �����ϴ� ���� ������ ��ť�� �Ͽ� ��Ȱ��ȭ��ŵ�ϴ�. --------
        target = null;

        triggerEvent?.Invoke(other);

        poolableObject?.EnQueue();
        // ---------------------------------------------------------------------
    }

    // �������� �����ϴ�.
    private void Hit(Collider other)
    {
        // �ｺ �������̽��� ������ ����� ��츸 �����մϴ�.
        other.GetComponent<IHealth>()?.Damage(5);
    }
}
