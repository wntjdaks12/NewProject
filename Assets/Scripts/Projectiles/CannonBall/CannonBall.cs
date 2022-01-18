using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CannonBall : Projectile
{
    private void Start()
    {
        projectileAttackBehaviour = this.gameObject.AddComponent<ProjectileSplashAttack>();

        projectileAttackBehaviour.Projectile = this;

        // Ÿ���� �����ϴ� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(projectile.speed));
    }
}