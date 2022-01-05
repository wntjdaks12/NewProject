using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ���� �� �ϳ��� �����Դϴ�.
/// </summary>
public class Pistol : RangedWeapon
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        if (CheckEmpty()) return;

        // ��Ÿ���� ���� �ƴ� �� ����ü�� �����մϴ�. -------------------------
        if(!CooldownTime.IsOperating) CreateProjectile();
        // -------------------------------------------------------------------

        // ��Ÿ���� �����մϴ�.
        CooldownTime.StartCooldownTime(weaponData.weaponInfo.cooldownTime);
    }

    /// <summary>
    /// ����ü�� �����մϴ�.
    /// </summary>
    private void CreateProjectile()
    {   
        // ����ü ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
        var obj = pool.DeQueue();

        if (!obj)
            return;

        if (obj.GetComponent<Projectile>())
        {
            // �浹�� �ݶ��̴����� ����ü���� ���� �����ڸ� �˷��ݴϴ�. -----------------
            var projectile = obj.GetComponent<Projectile>();

            projectile.Owner = transform.root.gameObject;
            projectile.target = AttackRange.GetColliders()[0].gameObject;
            // -------------------------------------------------------------------------

            // ��ġ�� �ʱ�ȭ ��ŵ�ϴ�. ---------------------------------------------------
            obj.transform.position = transform.root.position;
            obj.transform.rotation = transform.root.rotation;
            // --------------------------------------------------------------------------
        }
    }
}
