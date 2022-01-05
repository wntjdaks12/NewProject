using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponFacade
{
    // �ش� ������ ��Ÿ���Դϴ�.
    [SerializeField]
    private CooldownTime cooldownTime;

    // �ش� ������ ���� �����Դϴ�.
    [SerializeField]
    private AttackRange attackRange;

    /// <summary>
    /// �ش� ���⸦ �¾��� �մϴ�.
    /// </summary>
    /// <param name="owner">���� ���� ��ü</param>
    public void Setup() => CreateAttackRange();

    /// <summary>
    /// ���� ������ �����մϴ�.
    /// </summary>
    /// <param name="owner">���� ���� ��ü</param>
    private void CreateAttackRange()
    {
        // ���� ������ Ȱ��ȭ��ŵ�ϴ�.------------------------------------------------------------------------------------
        if (attackRange == null) return;

        var atkRangeObj = MonoBehaviour.Instantiate(attackRange.gameObject);
        attackRange = atkRangeObj?.GetComponent<AttackRange>();
        //---------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// �ش� ������ ��Ÿ�� �κ��Դϴ�.
    /// </summary>
    public CooldownTime CooldownTime { get => cooldownTime; }

    /// <summary>
    /// �ش� ������ ���� �����Դϴ�.
    /// </summary>
    public AttackRange AttackRange { get => attackRange;}
}
