using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �ش� ������ �⺻ ���� ��ư�Դϴ�.
public class BasicAttackButton : MonoBehaviour
{
    // �ش� ������ �⺻ ���� �̹����� �������� ���� ���� �����͸� �����ɴϴ�.
    [SerializeField]
    private WeaponData weaponData;

    // �⺻ ���� �̹����Դϴ�.
    [SerializeField]
    private Image basicAttackImg;

    private void Start()
    {
        // �⺻ ���� �̹����� ��ü�մϴ�. -----------------------------------
        if(weaponData != null)
            BasicAttackImg = weaponData.weaponInfo.basicAttackImg;
        // -----------------------------------------------------------------
    }

    public string BasicAttackImg { set { basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + value); } }
}
