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
        // ����ü�� �ش� �ð� ���� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => projectile.Disable());
    }

    private void Start()
    { 
        // �浹 ȿ���� �����ִ� ��Ʈ���Դϴ�.
        this.OnTriggerEnterAsObservable()
            .Where(_ => projectile != null)
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag) || projectile.Target == null)
            .Subscribe(other => projectile.TriggerEventHandler(other.gameObject));

        // Ÿ���� ���� ��� ����ü�� �ش� �������� �̵���Ű�� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Where(_ => projectile != null)
            .Where(_ => projectile.Target == null)
            .Subscribe(_ => projectile.Move());
    }
}
