using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : PlayerController
{
    private void Start()
    {
        //임시 데이터
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;

        target.Weapon = obj.GetComponent<Weapon>();
    }
}
