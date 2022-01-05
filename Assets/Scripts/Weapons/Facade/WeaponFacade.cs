using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponFacade
{
    // 해당 무기의 쿨타임입니다.
    [SerializeField]
    private CooldownTime cooldownTime;

    // 해당 무기의 공격 범위입니다.
    [SerializeField]
    private AttackRange attackRange;

    /// <summary>
    /// 해당 무기를 셋업을 합니다.
    /// </summary>
    /// <param name="owner">공격 범위 주체</param>
    public void Setup() => CreateAttackRange();

    /// <summary>
    /// 공격 범위를 생성합니다.
    /// </summary>
    /// <param name="owner">공격 범위 주체</param>
    private void CreateAttackRange()
    {
        // 공격 범위를 활성화시킵니다.------------------------------------------------------------------------------------
        if (attackRange == null) return;

        var atkRangeObj = MonoBehaviour.Instantiate(attackRange.gameObject);
        attackRange = atkRangeObj?.GetComponent<AttackRange>();
        //---------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 해당 무기의 쿨타임 부분입니다.
    /// </summary>
    public CooldownTime CooldownTime { get => cooldownTime; }

    /// <summary>
    /// 해당 무기의 공격 범위입니다.
    /// </summary>
    public AttackRange AttackRange { get => attackRange;}
}
