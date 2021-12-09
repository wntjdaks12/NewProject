using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : MonoBehaviour
{
    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    private void Start()
    {
        if (!target)
            return;
            
        //�ӽ� ������
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;
        obj.transform.localPosition = new Vector3(0, 0, 0);

        target.Weapon = obj.GetComponent<Weapon>();
    }
}
