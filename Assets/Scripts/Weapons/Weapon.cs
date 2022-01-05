using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected void Setup() => facade.Setup(transform.root.gameObject);

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
