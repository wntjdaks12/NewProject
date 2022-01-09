using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Beam : Projectile
{
    private void Start()
    {
        projectileBehaviour = this.gameObject.AddComponent<ProjectilePiercingAttack>();

        projectileBehaviour.Projectile = this;

        // 타겟을 추적하는 스트림입니다.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(1500));
    }
}
