using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 투사체의 기본 공격입니다.
/// </summary>
public class ProjectileBasicAttack : ProjectileAttackBehaviour
{
    private void Start()
    {
        // 타겟이 없을 경우 비활성화시키는 스트림입니다.
        this.UpdateAsObservable()
            .Where(_ => projectile != null)
            .Where(_ => projectile.Target == null)
            .Subscribe(_ => projectile.Disable());

        // 충돌 효과를 보여주는 스트림입니다.
        this.OnTriggerEnterAsObservable()
            .Where(_ => projectile != null)
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag))
            .Subscribe(other => projectile.TriggerEventHandler(other.gameObject));
    }
}
