using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

// 캐스팅된 개체를 관리합니다.
public class Caster : MonoBehaviour
{
    //무기 데이터입니다.
    [SerializeField]
    private WeaponData weaponData;

    //캐스터 데이터입니다.
    [SerializeField]
    private CastingData castingData;

    [SerializeField]
    private GameObject castingSignObj;

    private void Start()
    {
        castingSignObj = Instantiate(castingSignObj);
        castingSignObj.SetActive(false);

        var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

        clickStream
            .Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(300)))
            .Where(x => x.Count >= 2)
            .Subscribe(_ => Casting());
    }

    /// <summary>
    /// 캐스팅할 정보를 가져옵니다.
    /// </summary>
    private void Casting()
    {
        // 클릭한 위치에 있는 개체들을 가져옵니다.
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
                    castingData.target = hit.transform.gameObject;

                    if (!castingSignObj.activeSelf) castingSignObj.SetActive(true);

                    castingSignObj.transform.parent = hit.transform;
                    castingSignObj.transform.localPosition = new Vector3(0, 0, 0);
                }
            }

            if (castingData.target) castingData.target.GetComponent<ICastingPosition>().setPos(hit.point);
        }
    }

}
