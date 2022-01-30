using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �������Դϴ�.
/// </summary>
public class PistolGenerator : IWeaponGenerator
{
    /// <summary>
    /// �����մϴ�.
    /// </summary>
    public void Generate(Vector3 pos, Transform parent)
    {
        var obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/Weapons/Pistol")) as GameObject;

        obj.transform.parent = parent;
        parent.GetComponent<IEquipWeapon>().Equip(obj.GetComponent<Weapon>());
        obj.transform.position = pos;
    }
}
