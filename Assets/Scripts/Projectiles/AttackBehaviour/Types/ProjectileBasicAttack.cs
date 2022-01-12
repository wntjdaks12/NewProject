using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� �⺻ �����Դϴ�.
/// </summary>
public class ProjectileBasicAttack : ProjectileAttackBehaviour
{
    private void Start()
    {
        // ����ü�� �ش� �������� �̵���Ű�� ��Ʈ���Դϴ�.
        this.UpdateAsObservable()
            .Where(_ => projectile != null && projectile.Target == null)
            .Subscribe(_ => projectile.Destroy());

        this.OnTriggerEnterAsObservable()
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag))
            .Subscribe(other => projectile.asd(other.gameObject));
    }
}
