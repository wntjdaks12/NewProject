using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
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
    /// �ش� �÷��̾��Դϴ�.
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
    /// ���⸦ �����մϴ�.
    /// </summary>
    public void EquipWeapon()
    {
        if (weaponObj != null) Destroy(weaponObj);

        // �ڽ� ���� �����Ϳ��� �ش� ���̵��� ���⸦ ã���ϴ�. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_003");

        if (data == null) return;

        this.data = data;

        // ���� ������ ������ �Ѱ��ְ� ����� ���⸦ ��ü�մϴ�. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

        weapon.Data = data;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }*/

    

    // public WeaponInfo Data { get => data; }
}
