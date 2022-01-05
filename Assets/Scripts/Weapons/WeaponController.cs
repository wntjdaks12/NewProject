using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : MonoBehaviour
{
    //���� �������Դϴ�.
    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    private void Start()
    {
        // ����� ������ ��� ���⸦ �����մϴ�.
        if (target) EquipWeapon();
    }

    /// <summary>
    /// ���⸦ �����մϴ�.
    /// </summary>
    public void EquipWeapon()
    {
        // �ڽ� ���� �����Ϳ��� �ش� ���̵��� ���⸦ ã���ϴ�. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_001");

        if (data == null) return;

        weaponData.weaponInfo = data;
        // ----------------------------------------------------------------

        // �ش� ���⸦ �����ϰ� ��ġ�� �ʱ�ȭ��ŵ�ϴ�. -----------------------------------------------------------------------------------------
        var obj = Instantiate(Resources.Load("Prefabs/Weapons/" + weaponData.weaponInfo.keyName), target.transform) as GameObject;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // ���� ������ ������ �Ѱ��ְ� ����� ���⸦ ��ü�մϴ�. -------------
        var weapon = obj.GetComponent<Weapon>();

        weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }
}
