using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리에 속하는 무기입니다.
/// </summary>
public abstract class RangedWeapon : Weapon
{
    // 투사체를 필요로 하기 때문에 오브젝트 풀링을 사용합니다.
    [SerializeField]
    protected Pool pool;

    private void Start()
    {
        Setup();

        if (pool != null) pool.Init();
    }

    /// <summary>
    /// 널 체크합니다.
    /// </summary>
    /// <returns>널이 있으면 True 없으면 False를 리턴합니다.</returns>
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
    /// 투사체를 생성합니다.
    /// </summary>
    /// <param name="owner">소유자</param>
    /// <param name="target">대상</param>
    protected void CreateProjectile(GameObject owner, GameObject target)
    {
        if (CheckEmpty()) return;

        if (CooldownTime.IsOperating) return;

        // 투사체 오브젝트를 활성화시킵니다.
        var obj = pool.DeQueue();

        if (!obj)
            return;

        if (obj.GetComponent<Projectile>())
        {
            // 충돌한 콜라이더들을 투사체에게 대상과 소유자를 알려줍니다. -----------------
            var projectile = obj.GetComponent<Projectile>();

            projectile.Owner = owner;
            projectile.Target = target;
            // -------------------------------------------------------------------------

            // 위치를 초기화 시킵니다. ---------------------------------------------------
            obj.transform.position = transform.root.position;
            obj.transform.rotation = transform.root.rotation;
            // --------------------------------------------------------------------------
        }
    }
}
