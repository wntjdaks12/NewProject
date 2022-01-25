using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ��� ���ϴ� �����Դϴ�.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // ����ü�� �ʿ�� �ϱ� ������ ������Ʈ Ǯ���� ����մϴ�.
    [SerializeField]
    protected Pool pool;

    private void Start()
    {
        Setup();

        if (pool != null) pool.Init();
    }

    /// <summary>
    /// �� üũ�մϴ�.
    /// </summary>
    /// <returns>���� ������ True ������ False�� �����մϴ�.</returns>
    private bool CheckEmpty()
    {
        if (data == null)
            return true;

        if (CooldownTime == null || AttackRange == null)
            return true;

        if (pool != null)
            return false;

        return true;
    }

    /// <summary>
    /// ����ü�� �����մϴ�.
    /// </summary>
    /// <param name="owner">������</param>
    /// <param name="target">���</param>
    protected void CreateProjectile(GameObject owner, GameObject target)
    {
        if (CheckEmpty()) return;

        if (CooldownTime.IsOperating) return;

        // ����ü ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
        var obj = pool.DeQueue();

        if (!obj)
            return;

        if (obj.GetComponent<Projectile>())
        {
            // �浹�� �ݶ��̴����� ����ü���� ���� �����ڸ� �˷��ݴϴ�. -----------------
            var projectile = obj.GetComponent<Projectile>();

            projectile.Owner = owner;
            projectile.Target = target;
            // -------------------------------------------------------------------------

            // ��ġ�� �ʱ�ȭ ��ŵ�ϴ�. ---------------------------------------------------
            obj.transform.position = transform.root.position;
            obj.transform.rotation = transform.root.rotation;
            // --------------------------------------------------------------------------
        }
    }
}
