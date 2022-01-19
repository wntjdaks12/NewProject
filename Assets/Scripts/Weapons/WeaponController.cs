using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// �÷��̾��� ���⸦ �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class WeaponController : MonoBehaviour
{
    //���� �������Դϴ�.
    [SerializeField]
    private WeaponData weaponData;

    private GameObject weaponObj;

    [SerializeField]
    private CooldownTimeData cooldownTimeData;

    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    private void Start()
    {
        // ���� �������� ID���� ���� ��� �ش� ���⸦ �����ϴ� ��Ʈ���Դϴ�. 
        weaponData.ObserveEveryValueChanged(_ => weaponData.weaponInfo.id)
            .Subscribe(_ => EquipWeapon());
    }

    /// <summary>
    /// ���⸦ �����մϴ�.
    /// </summary>
    public void EquipWeapon()
    {
        if (weaponObj != null) Destroy(weaponObj);

        // �ڽ� ���� �����Ϳ��� �ش� ���̵��� ���⸦ ã���ϴ�. ---------------
        var data =  MyWeaponDatabase.SearchData("weapon_003");

        if (data == null) return;

        weaponData.weaponInfo = data;
        // ----------------------------------------------------------------

        // �ش� ���⸦ �����ϰ� ��ġ�� �ʱ�ȭ��ŵ�ϴ�. -----------------------------------------------------------------------------------------
        weaponObj = Instantiate(Resources.Load("Prefabs/Weapons/" + weaponData.weaponInfo.keyName), target.transform) as GameObject;
        weaponObj.transform.localPosition = new Vector3(0, 0, 0);
        // -----------------------------------------------------------------------------------------------------------------------------------

        // ���� ������ ������ �Ѱ��ְ� ����� ���⸦ ��ü�մϴ�. -------------
        var weapon = weaponObj.GetComponent<Weapon>();

        weapon.WeaponData = weaponData;
        target.Weapon = weapon;

        if(weapon.CooldownTime != null) cooldownTimeData.CooldownTimeInfo = weapon.CooldownTime.CooldownTimeInfo;
        // ---------------------------------------------------------------
    }
}
