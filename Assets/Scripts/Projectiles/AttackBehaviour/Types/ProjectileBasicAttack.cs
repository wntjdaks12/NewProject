using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� �⺻ �����Դϴ�.
/// </summary>
public class ProjectileBasicAttack : ProjectileAttackBehaviour
{
    private void OnEnable()
    {
        // ����ü�� �ش� �������� �̵���Ű�� ��Ʈ���Դϴ�.
        this.UpdateAsObservable()
            .Where(_ => projectile != null && projectile.Target == null)
            .Subscribe(_ => projectile.Destroy());
    }
}
