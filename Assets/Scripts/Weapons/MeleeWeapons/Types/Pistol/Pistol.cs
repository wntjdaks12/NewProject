using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리 무기 중 하나인 권총입니다.
/// </summary>
public class Pistol : RangedWeapon
{
    public new void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public override void Attack()
    {
        if (pool && cooldownTime.stateType == CooldownTime.StateType.None)
        {
            // 풀링 된 오브젝트를 활성화시키고 위치값을 초기화시킵니다. -------------------------------
            var obj = pool.DeQueue();

            if (!obj)
                return;

            obj.transform.position = transform.root.position;
            // ------------------------------------------------------------------------------------

            if (obj.GetComponent<Projectile>())
                // 충돌한 콜라이더들을 투사체에게 대상을 알려줍니다.  
                obj.GetComponent<Projectile>().target = attackRange.GetColliders()[0].gameObject;
        }

        // 쿨타임을 적용합니다.
        cooldownTime?.StartCooldownTime();
    }
}
