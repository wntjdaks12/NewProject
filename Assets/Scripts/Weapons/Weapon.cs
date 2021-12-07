using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ������ �ֻ����Դϴ�.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    // �ش� ������ ��Ÿ���Դϴ�.
    protected CooldownTime cooldownTime;

    // �ش� ������ ���� ���� ������Ʈ�Դϴ�.
    [SerializeField]
    private GameObject attackRangeObject;
    // �ش� ������ ���� �����Դϴ�.
    protected AttackRange attackRange;

    /// <summary>
    /// �����մϴ�.
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
    /// �ش� ���⸦ �¾��� �մϴ�.
    /// </summary>
    public void Setup()
    {
        if (!attackRangeObject)
            return;

        // ���� ������ Ȱ��ȭ��ŵ�ϴ�.------------------------------------------------------------------------------------
        attackRangeObject = Instantiate(attackRangeObject);
        attackRange = attackRangeObject.GetComponent<AttackRange>() ?? attackRangeObject.GetComponent<AttackRange>();
        attackRange?.Active(transform.root.gameObject, 10);
        //---------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// �ش� ������ ���� �����Դϴ�.
    /// </summary>
    public AttackRange AttackRange { get { return attackRange; } }
}
