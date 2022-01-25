using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : MonoBehaviour
{
    private WeaponInfo data;

    private GameObject weaponObj;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    private void Start() => EquipWeapon();

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
        // ----------------------------------------------------------------

        // �ش� ���⸦ �����ϰ� ��ġ�� �ʱ�ȭ��ŵ�ϴ�. -----------------------------------------------------------------------------------------
        weaponObj = Instantiate(Resources.Load("Prefabs/Weapons/" + this.data.keyName), target.transform) as GameObject;
        weaponObj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // ���� ������ ������ �Ѱ��ְ� ����� ���⸦ ��ü�մϴ�. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

      //  weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }

    public WeaponInfo Data { get => data; }
}
