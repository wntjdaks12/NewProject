using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기 생성자입니다.
/// </summary>
public class PistolGenerator : IWeaponGenerator
{
    /// <summary>
    /// 생성합니다.
    /// </summary>
    public void Generate(Vector3 pos, Transform parent)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Weapons/Pistol")) as GameObject;

        obj.transform.parent = parent;
        parent.GetComponent<IEquipWeapon>().Equip(obj.GetComponent<Weapon>());
        obj.transform.position = pos;
    }
}
