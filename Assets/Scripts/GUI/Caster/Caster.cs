using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

// ĳ���õ� ��ü�� �����մϴ�.
public class Caster : MonoBehaviour
{
    //���� �������Դϴ�.
    [SerializeField]
    private WeaponData weaponData;

    //ĳ���� �������Դϴ�.
    [SerializeField]
    private CastingData castingData;

    private void Start()
    {
        var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

        clickStream
            .Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(300)))
            .Where(x => x.Count >= 2)
            .Subscribe(_ => Casting());
    }

    /// <summary>
    /// ĳ������ ������ �����ɴϴ�.
    /// </summary>
    private void Casting()
    {
        // Ŭ���� ��ġ�� �ִ� ��ü���� �����ɴϴ�.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                if (weaponData != null && weaponData.weaponInfo != null)
                    weaponData.weaponInfo = hit.transform.GetComponentInChildren<WeaponController>()?.Data;

                if (castingData != null)
                {
                    castingData.pos = hit.transform.position;
                    castingData.target = hit.transform.gameObject;
                }
            }

            if (castingData.target) castingData.pos = hit.point;
        }
    }

}
