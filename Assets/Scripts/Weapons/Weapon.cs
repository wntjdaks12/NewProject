using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 모든 무기의 최상위입니다.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    // 해당 무기의 id 값입니다.
    protected string id;
    
    /// 해당 무기의 시스템을 하나로 구조화시킵니다.
    /// </summary>
    [SerializeField]
    private WeaponFacade facade;

    /// <summary>
    /// 해당 무기를 셋업을 합니다.
    /// </summary>
    public void Setup(WeaponInfo data) 
    {
        facade.Setup();

        // 공격 범위를 활성화합니다.
        AttackRange.Active(transform.root.gameObject, data.range);

        data.ObserveEveryValueChanged(val => val.cooldownTime)
            .Subscribe(cooldownTime => CooldownTime.CooldownTimeInfo.cooldownTime = cooldownTime);

        // 공격 범위 값이 변경될 경우 값을 갱신해 주는 스트림입니다.
        data.ObserveEveryValueChanged(val => val.range)
            .Subscribe(radius => AttackRange.Radius = radius);
    }

    /// <summary>
    /// 해당 무기의 id 값입니다.
    /// </summary>
    public string Id { get => id; }

    /// <summary>
    /// 공격합니다.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// 해당 무기의 쿨타임 부분입니다.
    /// </summary>
    public CooldownTime CooldownTime { get => facade.CooldownTime; }

    /// <summary>
    /// 해당 무기의 공격 범위입니다.
    /// </summary>
    public AttackRange AttackRange { get => facade.AttackRange; }
}
