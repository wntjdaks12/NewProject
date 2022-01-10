using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// d
/// </summary>
public class IntentorySlotModel
{
    // ���� �������Դϴ�.
    private WeaponData weaponData;

    public IntentorySlotModel() => weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");

    // �ش� �ε����� �����Դϴ�.
    public WeaponInfo getWeaponInfo(int index) => MyWeaponDatabase.getData(index);

    /// <summary>
    /// �ش� ���� ������ �����Դϴ�.
    /// </summary>
    public WeaponInfo WeaponInfo 
    { set {
            if (weaponData != null) weaponData.weaponInfo = value;
        } }
}
