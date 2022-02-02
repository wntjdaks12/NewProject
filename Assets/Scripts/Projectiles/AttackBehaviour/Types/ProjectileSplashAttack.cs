using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� ���÷��� �����Դϴ�.
/// </summary>
public class ProjectileSplashAttack : ProjectileAttackBehaviour
{
    private void Start()
    {
        // Ÿ���� ���� ��� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        this.UpdateAsObservable()
            .Where(_ => projectile != null)
            .Where(_ => projectile.Target == null)
            .Subscribe(_ => projectile.Disable());

        // �浹 ȿ���� �����ִ� ��Ʈ���Դϴ�.
        this.OnTriggerEnterAsObservable()
            .Where(_ => projectile != null)
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag))
            .Subscribe(other => CheckSplash());
    }

    /// <summary>
    /// ���÷��ø� üũ�մϴ�.
    /// </summary>
    private void CheckSplash()
    {
        // �ش� �ݰ� ���� �浹ü�� �˻��մϴ�.
        Collider[] colls = Physics.OverlapSphere(transform.position, 5, 1 << 6);

        foreach (Collider coll in colls)
        {
            projectile.TriggerEventHandler(coll.gameObject);
        }
    }
}
