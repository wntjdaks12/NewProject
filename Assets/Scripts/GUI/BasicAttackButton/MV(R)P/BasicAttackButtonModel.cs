using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 기본 공격 슬롯의 데이터 부분입니다.
/// </summary>
public class BasicAttackButtonModel
{
    // 무기 데이터입니다.
    private WeaponData weaponData;

    public BasicAttackButtonModel()
    {
        weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");
        weaponData.weaponInfo = new WeaponInfo(null, null, "BasicAttack_Null", 0, 0);
    }

    // 무기의 기본 공격 이미지를 리턴합니다.
    public string BasicAttackImage { get => weaponData.weaponInfo.basicAttackImg; }
}
