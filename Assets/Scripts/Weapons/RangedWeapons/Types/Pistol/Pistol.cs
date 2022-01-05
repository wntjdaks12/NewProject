using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리 무기 중 하나인 권총입니다.
/// </summary>
public class Pistol : RangedWeapon
{
    /// <summary>
    /// 공격합니다.
    /// </summary>
    public override void Attack()
    {
        if (CheckEmpty()) return;

        // 쿨타임이 쿨링이 아닐 시 투사체를 생성합니다. -------------------------
        if(!CooldownTime.IsOperating) CreateProjectile();
        // -------------------------------------------------------------------

        // 쿨타임을 적용합니다.
        CooldownTime.StartCooldownTime(weaponData.weaponInfo.cooldownTime);
    }

    /// <summary>
    /// 투사체를 생성합니다.
    /// </summary>
    private void CreateProjectile()
    {   
        // 투사체 오브젝트를 활성화시킵니다.
        var obj = pool.DeQueue();

        if (!obj)
            return;

        if (obj.GetComponent<Projectile>())
        {
            // 충돌한 콜라이더들을 투사체에게 대상과 소유자를 알려줍니다. -----------------
            var projectile = obj.GetComponent<Projectile>();

            projectile.Owner = transform.root.gameObject;
            projectile.target = AttackRange.GetColliders()[0].gameObject;
            // -------------------------------------------------------------------------

            // 위치를 초기화 시킵니다. ---------------------------------------------------
            obj.transform.position = transform.root.position;
            obj.transform.rotation = transform.root.rotation;
            // --------------------------------------------------------------------------
        }
    }
}
