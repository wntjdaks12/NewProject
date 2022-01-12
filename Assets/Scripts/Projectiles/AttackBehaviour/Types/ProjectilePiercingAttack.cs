using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� ���� �����Դϴ�.
/// </summary>
public class ProjectilePiercingAttack : ProjectileAttackBehaviour
{
    private void OnEnable()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => projectile.Destroy());
    }

    private void Start()
    { 
        // �ش� ����ü�� 1�� �Ŀ� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        this.OnTriggerEnterAsObservable()
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag) || projectile.Target == null)
            .Subscribe(other => projectile.asd(other.gameObject));

        // Ÿ���� �����ϴ� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Where(other => projectile.Target == null)
            .Subscribe(_ => projectile.Move(700));
    }
}
