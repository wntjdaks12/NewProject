using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BasicAttackButtonModel
{
    public StringReactiveProperty basicAttackImageRP = new StringReactiveProperty();

    private WeaponData weaponData;
    public BasicAttackButtonModel()
    {
        weaponData = (WeaponData)Resources.Load("Datas/ScriptableObjects/Weapon/Weapon Data");
    }

    public string BasicAttackImage { get => weaponData.weaponInfo.basicAttackImg; }
}
