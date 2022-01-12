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
        // 투사체를 해당 시간 이후 비활성화시키는 스트림입니다.
        Observable.Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => projectile.Disable());
    }

    private void Start()
    { 
        // 충돌 효과를 보여주는 스트림입니다.
        this.OnTriggerEnterAsObservable()
            .Where(_ => projectile != null)
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag) || projectile.Target == null)
            .Subscribe(other => projectile.TriggerEventHandler(other.gameObject));

        // 타겟이 없을 경우 투사체를 해당 방향으로 이동시키는 스트림입니다.
        this.FixedUpdateAsObservable()
            .Where(_ => projectile != null)
            .Where(_ => projectile.Target == null)
            .Subscribe(_ => projectile.Move());
    }
}
