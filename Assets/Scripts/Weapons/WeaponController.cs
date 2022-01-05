using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : MonoBehaviour
{
    //무기 데이터입니다.
    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    private void Start()
    {
        // 대상이 존재할 경우 무기를 장착합니다.
        if (target) EquipWeapon();
    }

    /// <summary>
    /// 무기를 장착합니다.
    /// </summary>
    public void EquipWeapon()
    {
        // 자신 무기 데이터에서 해당 아이디의 무기를 찾습니다. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_001");

        if (data == null) return;

        weaponData.weaponInfo = data;
        // ----------------------------------------------------------------

        // 해당 무기를 생성하고 위치를 초기화시킵니다. -----------------------------------------------------------------------------------------
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/" + weaponData.weaponInfo.keyName), target.transform) as GameObject;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // 무기 데이터 정보를 넘겨주고 대상의 무기를 교체합니다. -------------
        var weapon = obj.GetComponent<Weapon>();

        weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }
}
