using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Beam : Projectile
{
    private void Start()
    {
        projectileAttackBehaviour = this.gameObject.AddComponent<ProjectilePiercingAttack>();

        projectileAttackBehaviour.Projectile = this;

        // Ÿ���� �����ϴ� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(1500));
    }
}
