using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : MonoBehaviour
{
    private WeaponInfo data;

    private GameObject weaponObj;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    private void Start() => EquipWeapon();

    /// <summary>
    /// 무기를 장착합니다.
    /// </summary>
    public void EquipWeapon()
    {
        if (weaponObj != null) Destroy(weaponObj);

        // 자신 무기 데이터에서 해당 아이디의 무기를 찾습니다. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_003");

        if (data == null) return;

        this.data = data;
        // ----------------------------------------------------------------

        // 해당 무기를 생성하고 위치를 초기화시킵니다. -----------------------------------------------------------------------------------------
        weaponObj = Instantiate(Resources.Load("Prefabs/Weapons/" + this.data.keyName), target.transform) as GameObject;
        weaponObj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // 무기 데이터 정보를 넘겨주고 대상의 무기를 교체합니다. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

      //  weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }

    public WeaponInfo Data { get => data; }
}
