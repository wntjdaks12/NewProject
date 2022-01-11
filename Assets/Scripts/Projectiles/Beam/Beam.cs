using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� �ϳ��� ���Դϴ�.
/// </summary>
public class Beam : Projectile
{
    private void Start()
    {
        // �ش� ����ü�� ���� ������ �մϴ�. ------------------------------------------------------------
        projectileAttackBehaviour = this.gameObject.AddComponent<ProjectilePiercingAttack>();

        projectileAttackBehaviour.Projectile = this;
        // --------------------------------------------------------------------------------------------

        // Ÿ���� �����ϴ� ��Ʈ���Դϴ�.
        this.FixedUpdateAsObservable()
            .Subscribe(_ => Trace(projectile.speed));
    }
}
