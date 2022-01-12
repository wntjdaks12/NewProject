using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 투사체의 관통 공격입니다.
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
        // 해당 투사체를 1초 후에 비활성화시키는 스트림입니다.
        this.OnTriggerEnterAsObservable()
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag) || projectile.Target == null)
            .Subscribe(other => projectile.asd(other.gameObject));

        // 타겟을 추적하는 스트림입니다.
        this.FixedUpdateAsObservable()
            .Where(other => projectile.Target == null)
            .Subscribe(_ => projectile.Move(700));
    }
}
