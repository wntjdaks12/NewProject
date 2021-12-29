using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 무기의 최상위입니다.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// 무기 데이터입니다.
    /// </summary>
    protected WeaponData weaponData;

    [SerializeField]
    private WeaponFacade facade;

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public abstract void Attack();

    protected void Start()
    {
        facade.Setup(transform.root.gameObject);
    }

    /// <summary>
    /// 해당 무기 데이터 정보입니다.
    /// </summary>
    public WeaponData WeaponData { set => weaponData = value; }

    /// <summary>
    /// 해당 무기의 쿨타임 부분입니다.
    /// </summary>
    public CooldownTime CooldownTime { get => facade.CooldownTime; }

    /// <summary>
    /// 해당 무기의 공격 범위입니다.
    /// </summary>
    public AttackRange AttackRange { get => facade.AttackRange; }
}
