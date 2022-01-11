using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PistolBullet : Projectile
{
    private void Start()
    {
        projectileAttackBehaviour = this.gameObject.AddComponent<ProjectileBasicAttack>();

        projectileAttackBehaviour.Projectile = this;

        // Ÿ���� �����ϴ� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(1500));
    }
}
