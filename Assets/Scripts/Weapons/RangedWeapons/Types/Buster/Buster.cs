using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : RangedWeapon
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        // ��Ÿ���� ���� �ƴ� �� ����ü�� �����մϴ�. -------------------------
        CreateProjectile(transform.root.gameObject, AttackRange.GetColliders()[0].gameObject);

        // ��Ÿ���� �����մϴ�.
        CooldownTime.StartCooldownTime(weaponData.weaponInfo.cooldownTime);
    }

}
