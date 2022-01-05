using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ��� ������ �ֻ����Դϴ�.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// ���� �������Դϴ�.
    /// </summary>
    protected WeaponData weaponData;

    /// <summary>
    /// �ش� ������ �ý����� �ϳ��� ����ȭ��ŵ�ϴ�.
    /// </summary>
    [SerializeField]
    private WeaponFacade facade;

    /// <summary>
    /// �ش� ���⸦ �¾��� �մϴ�.
    /// </summary>
    protected void Setup() 
    {
        if (weaponData == null) return;

        facade.Setup();

        // ���� ������ Ȱ��ȭ�մϴ�.
        AttackRange.Active(transform.root.gameObject, weaponData.weaponInfo.range);

        // ���� ���� ���� ����� ��� ���� ������ �ִ� ��Ʈ���Դϴ�.
        weaponData.ObserveEveryValueChanged(val => val.weaponInfo.range)
            .Subscribe(radius => AttackRange.Radius = radius);
    }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// �ش� ���� ������ �����Դϴ�.
    /// </summary>
    public WeaponData WeaponData { set => weaponData = value; }

    /// <summary>
    /// �ش� ������ ��Ÿ�� �κ��Դϴ�.
    /// </summary>
    public CooldownTime CooldownTime { get => facade.CooldownTime; }

    /// <summary>
    /// �ش� ������ ���� �����Դϴ�.
    /// </summary>
    public AttackRange AttackRange { get => facade.AttackRange; }
}
