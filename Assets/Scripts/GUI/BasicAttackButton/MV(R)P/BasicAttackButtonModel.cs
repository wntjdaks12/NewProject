using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// �⺻ ���� ������ ������ �κ��Դϴ�.
/// </summary>
public class BasicAttackButtonModel
{
    // ���� �������Դϴ�.
    private WeaponData weaponData;

    public BasicAttackButtonModel()
    {
        weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");
        weaponData.weaponInfo = new WeaponInfo(null, null, "BasicAttack_Null", null, 0, 0);
    }

    // ������ �⺻ ���� �̹����� �����մϴ�.
    public string BasicAttackImage { get => weaponData.weaponInfo.basicAttackImg; }
}
