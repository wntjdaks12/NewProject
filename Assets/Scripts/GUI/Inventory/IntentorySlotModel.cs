using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// d
/// </summary>
public class IntentorySlotModel
{
    // 무기 데이터입니다.
    private WeaponData weaponData;

    public IntentorySlotModel() => weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");

    // 해당 인덱스의 무기입니다.
    public WeaponInfo getWeaponInfo(int index) => MyWeaponDatabase.getData(index);

    /// <summary>
    /// 해당 무기 데이터 정보입니다.
    /// </summary>
    public WeaponInfo WeaponInfo 
    { set {
            if (weaponData != null) weaponData.weaponInfo = value;
        } }
}
