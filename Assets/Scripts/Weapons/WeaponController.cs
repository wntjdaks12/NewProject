using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 무기를 제어하는 컨트롤러입니다.
/// </summary>
public class WeaponController : MonoBehaviour
{
    private WeaponInfo data;

    /* private GameObject weaponObj;

     [SerializeField]
     private CooldownTimeData cooldownTimeData;

     [SerializeField]
     private WeaponGenerator weaponGenerator;*/

    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Weapon target;

    private void Start() => DataLoad();

    private void DataLoad()
    {
        if (!target) return;

        var data = MyWeaponDatabase.SearchData(target.Id);
        this.data = data;

        target.Setup(data);
    }

    public WeaponInfo Data{get => data;}

    // private void Start() => EquipWeapon();

    /*
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

        // 무기 데이터 정보를 넘겨주고 대상의 무기를 교체합니다. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

        weapon.Data = data;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }*/

    

    // public WeaponInfo Data { get => data; }
}
