using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : MonoBehaviour
{
    //무기 데이터입니다.
    [SerializeField]
    private WeaponData weaponData;

    private GameObject weaponObj;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    private void Start()
    {
        // 무기 데이터의 ID값이 변할 경우 해당 무기를 장착하는 스트림입니다. 
        weaponData.ObserveEveryValueChanged(_ => weaponData.weaponInfo.id)
            .Subscribe(_ => EquipWeapon());
    }

    /// <summary>
    /// 무기를 장착합니다.
    /// </summary>
    public void EquipWeapon()
    {
        if (weaponObj != null) Destroy(weaponObj);

        // 자신 무기 데이터에서 해당 아이디의 무기를 찾습니다. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_003");

        if (data == null) return;

        weaponData.weaponInfo = data;
        // ----------------------------------------------------------------

        // 해당 무기를 생성하고 위치를 초기화시킵니다. -----------------------------------------------------------------------------------------
        weaponObj = Instantiate(Resources.Load("Prefabs/Weapons/" + weaponData.weaponInfo.keyName), target.transform) as GameObject;
        weaponObj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // 무기 데이터 정보를 넘겨주고 대상의 무기를 교체합니다. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

        weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }
}
