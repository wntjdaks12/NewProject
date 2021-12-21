using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 해당 무기의 기본 공격 버튼입니다.
public class BasicAttackButton : MonoBehaviour
{
    // 해당 무기의 기본 공격 이미지를 가져오기 위해 무기 데이터를 가져옵니다.
    [SerializeField]
    private WeaponData weaponData;

    // 기본 공격 이미지입니다.
    [SerializeField]
    private Image basicAttackImg;

    private void Start()
    {
        // 기본 공격 이미지를 교체합니다. -----------------------------------
        if(weaponData != null)
            BasicAttackImg = weaponData.weaponInfo.basicAttackImg;
        // -----------------------------------------------------------------
    }

    public string BasicAttackImg { set { basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + value); } }
}
