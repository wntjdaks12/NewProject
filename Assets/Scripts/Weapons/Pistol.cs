using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �پ��� ������ �ϳ��� �����Դϴ�.
/// </summary>
public class Pistol : Weapon
{
    // ��Ÿ�� ������Ʈ�Դϴ�.
    private CooldownTime cooldownTime;

    public void Awake()
    {
        cooldownTime = GetComponent<CooldownTime>() ?? GetComponent<CooldownTime>();
    }
    
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public override void Attack()
    {
        cooldownTime?.StartCooldownTime();
    }
}
