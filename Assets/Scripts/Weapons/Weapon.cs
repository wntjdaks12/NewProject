using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 무기의 최상위입니다.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    // 해당 무기의 쿨타임입니다.
    protected CooldownTime cooldownTime;

    // 해당 무기의 공격 범위 오브젝트입니다.
    [SerializeField]
    private GameObject attackRangeObject;
    // 해당 무기의 공격 범위입니다.
    protected AttackRange attackRange;

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public abstract void Attack();

    protected void Awake()
    {
        cooldownTime = GetComponent<CooldownTime>() ?? GetComponent<CooldownTime>();
    }

    protected void Start()
    {
        Setup();
    }

    /// <summary>
    /// 해당 무기를 셋업을 합니다.
    /// </summary>
    public void Setup()
    {
        if (!attackRangeObject)
            return;

        // 공격 범위를 활성화시킵니다.------------------------------------------------------------------------------------
        attackRangeObject = Instantiate(attackRangeObject);
        attackRange = attackRangeObject.GetComponent<AttackRange>() ?? attackRangeObject.GetComponent<AttackRange>();
        attackRange?.Active(transform.root.gameObject, 10);
        //---------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 해당 무기의 공격 범위입니다.
    /// </summary>
    public AttackRange AttackRange { get { return attackRange; } }
}
