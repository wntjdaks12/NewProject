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
    // �ش� ������ id ���Դϴ�.
    protected string id;
    
    /// �ش� ������ �ý����� �ϳ��� ����ȭ��ŵ�ϴ�.
    /// </summary>
    [SerializeField]
    private WeaponFacade facade;

    /// <summary>
    /// �ش� ���⸦ �¾��� �մϴ�.
    /// </summary>
    public void Setup(WeaponInfo data) 
    {
        facade.Setup();

        // ���� ������ Ȱ��ȭ�մϴ�.
        AttackRange.Active(transform.root.gameObject, data.range);

        data.ObserveEveryValueChanged(val => val.cooldownTime)
            .Subscribe(cooldownTime => CooldownTime.CooldownTimeInfo.cooldownTime = cooldownTime);

        // ���� ���� ���� ����� ��� ���� ������ �ִ� ��Ʈ���Դϴ�.
        data.ObserveEveryValueChanged(val => val.range)
            .Subscribe(radius => AttackRange.Radius = radius);
    }

    /// <summary>
    /// �ش� ������ id ���Դϴ�.
    /// </summary>
    public string Id { get => id; }

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public abstract void Attack();

    /// <summary>
    /// �ش� ������ ��Ÿ�� �κ��Դϴ�.
    /// </summary>
    public CooldownTime CooldownTime { get => facade.CooldownTime; }

    /// <summary>
    /// �ش� ������ ���� �����Դϴ�.
    /// </summary>
    public AttackRange AttackRange { get => facade.AttackRange; }
}
