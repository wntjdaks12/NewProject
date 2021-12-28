using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ���� �� �ϳ��� �����Դϴ�.
/// </summary>
public class Pistol : RangedWeapon
{
    public new void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        if (weaponInfo == null)
            return;

        if (pool && !cooldownTime.IsOperating)
        {
            // Ǯ�� �� ������Ʈ�� Ȱ��ȭ��Ű�� ��ġ���� �ʱ�ȭ��ŵ�ϴ�. -------------------------------
            var obj = pool.DeQueue();

            if (!obj)
                return;

            if (obj.GetComponent<Projectile>())
            {
                // �浹�� �ݶ��̴����� ����ü���� ���� �����ڸ� �˷��ݴϴ�. -----------------
                var projectile = obj.GetComponent<Projectile>();

                projectile.Owner = transform.root.gameObject;
                projectile.target = attackRange.GetColliders()[0].gameObject;
                // -------------------------------------------------------------------------

                obj.transform.position = transform.root.position;
                obj.transform.rotation = transform.root.rotation;
            }
            // ------------------------------------------------------------------------------------


        }

        // ��Ÿ���� �����մϴ�.
        cooldownTime?.StartCooldownTime(weaponInfo.cooldownTime);
    }
}
