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
        // 투사체를 해당 방향으로 이동시키는 스트림입니다.
        this.UpdateAsObservable()
            .Where(_ => projectile != null && projectile.Target == null)
            .Subscribe(_ => projectile.Destroy());

        this.OnTriggerEnterAsObservable()
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag))
            .Subscribe(other => projectile.asd(other.gameObject));
    }
}
