using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 투사체중 하나인 빔입니다.
/// </summary>
public class Beam : Projectile
{
    private void Start()
    {
        // 해당 투사체는 관통 공격을 합니다. ------------------------------------------------------------
        projectileAttackBehaviour = this.gameObject.AddComponent<ProjectilePiercingAttack>();

        projectileAttackBehaviour.Projectile = this;
        // --------------------------------------------------------------------------------------------

        // 타겟을 추적하는 스트림입니다.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(projectile.speed));
    }
}
