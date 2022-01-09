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
        // 타겟이 사라져도 해당 방향으로 이동하는 스트림입니다.  
        this.FixedUpdateAsObservable()
            .Where(_ => projectile != null && projectile.Target == null)
            .Subscribe(_ => projectile.Move(1500));

        // 해당 투사체를 1초 후에 비활성화시키는 스트림입니다.
        Observable.
            Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => projectile.Destroy());
    }
}
