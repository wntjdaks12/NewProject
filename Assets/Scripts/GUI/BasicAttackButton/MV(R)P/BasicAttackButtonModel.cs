using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 기본 공격 슬롯의 데이터 부분입니다.
/// </summary>
public class BasicAttackButtonModel
{
    // 기본 공격 이미지의 반응성 프로퍼티입니다.
    public StringReactiveProperty basicAttackImageRP = new StringReactiveProperty();

    // 무기 데이터입니다.
    private WeaponData weaponData;

    public BasicAttackButtonModel() => weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");

    // 무기의 기본 공격 이미지를 리턴합니다.
    public string BasicAttackImage { get => weaponData.weaponInfo.basicAttackImg; }
}
