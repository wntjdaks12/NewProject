using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : MonoBehaviour
{
    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    private void Start()
    {
        if (!target)
            return;
            
        //임시 데이터
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/Pistol"), target.transform) as GameObject;
        obj.transform.localPosition = new Vector3(0, 0, 0);

        target.Weapon = obj.GetComponent<Weapon>();
    }
}
