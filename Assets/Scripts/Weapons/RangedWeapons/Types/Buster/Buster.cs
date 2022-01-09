using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : RangedWeapon
{
    /// <summary>
    /// 공격합니다.
    /// </summary>
    public override void Attack()
    {
        // 쿨타임이 쿨링이 아닐 시 투사체를 생성합니다. -------------------------
        CreateProjectile(transform.root.gameObject, AttackRange.GetColliders()[0].gameObject);

        // 쿨타임을 적용합니다.
        CooldownTime.StartCooldownTime(weaponData.weaponInfo.cooldownTime);
    }

}
