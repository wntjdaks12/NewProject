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
    /// 
    [SerializeField]
    protected WeaponInfo data;

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
        if (data == null) return;

        facade.Setup();

        // ���� ������ Ȱ��ȭ�մϴ�.
        AttackRange.Active(transform.root.gameObject, data.range);

        // ���� ���� ���� ����� ��� ���� ������ �ִ� ��Ʈ���Դϴ�.
        data.ObserveEveryValueChanged(val => val.range)
            .Subscribe(radius => AttackRange.Radius = radius);
    }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// �ش� ���� ������ �����Դϴ�.
    /// </summary>
    public WeaponInfo Data { set => data = value; }

    /// <summary>
    /// �ش� ������ ��Ÿ�� �κ��Դϴ�.
    /// </summary>
    public CooldownTime CooldownTime { get => facade.CooldownTime; }

    /// <summary>
    /// �ش� ������ ���� �����Դϴ�.
    /// </summary>
    public AttackRange AttackRange { get => facade.AttackRange; }
}
