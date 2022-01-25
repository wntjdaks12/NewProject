using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class PlayerRayCast : MonoBehaviour
{
    //무기 데이터입니다.
    [SerializeField]
    private WeaponData weaponData;

    private void Start() =>
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(a => Raycast());

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (weaponData != null && weaponData.weaponInfo != null)
                if(hit.transform.tag == "Player")
                    weaponData.weaponInfo = hit.transform.GetComponentInChildren<WeaponController>()?.Data;
        }
    }
}
