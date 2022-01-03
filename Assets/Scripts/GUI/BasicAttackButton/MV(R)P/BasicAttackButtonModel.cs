using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// �⺻ ���� ������ ������ �κ��Դϴ�.
/// </summary>
public class BasicAttackButtonModel
{
    // �⺻ ���� �̹����� ������ ������Ƽ�Դϴ�.
    public StringReactiveProperty basicAttackImageRP = new StringReactiveProperty();

    // ���� �������Դϴ�.
    private WeaponData weaponData;

    public BasicAttackButtonModel() => weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");

    // ������ �⺻ ���� �̹����� �����մϴ�.
    public string BasicAttackImage { get => weaponData.weaponInfo.basicAttackImg; }
}
