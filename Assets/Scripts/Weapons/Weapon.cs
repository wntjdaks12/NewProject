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

    [SerializeField]
    private WeaponFacade facade;

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Attack();

    protected void Start()
    {
        facade.Setup(transform.root.gameObject);
    }

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
