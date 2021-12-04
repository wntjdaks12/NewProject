using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : PlayerController
{
    private void Start()
    {
        //�ӽ� ������
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;

        target.Weapon = obj.GetComponent<Weapon>();
    }
}
