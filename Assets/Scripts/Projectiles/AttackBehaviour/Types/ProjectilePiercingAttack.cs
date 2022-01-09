using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ����ü�� ���� �����Դϴ�.
/// </summary>
public class ProjectilePiercingAttack : ProjectileAttackBehaviour
{
    private void OnEnable()
    { 
        // Ÿ���� ������� �ش� �������� �̵��ϴ� ��Ʈ���Դϴ�.  
        this.FixedUpdateAsObservable()
            .Where(_ => projectile != null && projectile.Target == null)
            .Subscribe(_ => projectile.Move(1500));

        // �ش� ����ü�� 1�� �Ŀ� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        Observable.
            Timer(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => projectile.Destroy());
    }
}
