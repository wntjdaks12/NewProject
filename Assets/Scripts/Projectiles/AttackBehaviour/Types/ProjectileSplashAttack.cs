using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 투사체의 스플래시 공격입니다.
/// </summary>
public class ProjectileSplashAttack : ProjectileAttackBehaviour
{
    private void Start()
    {
        // 타겟이 없을 경우 비활성화시키는 스트림입니다.
        this.UpdateAsObservable()
            .Where(_ => projectile != null)
            .Where(_ => projectile.Target == null)
            .Subscribe(_ => projectile.Disable());

        // 충돌 효과를 보여주는 스트림입니다.
        this.OnTriggerEnterAsObservable()
            .Where(_ => projectile != null)
            .Where(other => (projectile.Target != null && other.tag == projectile.Target.tag))
            .Subscribe(other => CheckSplash());
    }

    /// <summary>
    /// 스플래시를 체크합니다.
    /// </summary>
    private void CheckSplash()
    {
        // 해당 반경 안의 충돌체를 검사합니다.
        Collider[] colls = Physics.OverlapSphere(transform.position, 5, 1 << 6);

        foreach (Collider coll in colls)
        {
            projectile.TriggerEventHandler(coll.gameObject);
        }
    }
}
