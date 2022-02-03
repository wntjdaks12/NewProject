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

    //캐스팅 데이터입니다.
    [SerializeField]
    private CastingData castingData;

    // 캐스팅을 표시할 오브젝트입니다.
    [SerializeField]
    private GameObject castingSignObj;

    private void Start()
    {
        castingSignObj = Instantiate(castingSignObj);
        castingSignObj.SetActive(false);

        // 0.3초 내로 더블클릭을 할 시 캐스팅을 합니다.
        var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

        clickStream
            .Timestamp()
            .Pairwise((prev, cur) => (cur. Timestamp - prev.Timestamp).TotalMilliseconds <= 300)
            .Where(fastEnough => fastEnough)
            .Subscribe(x => Casting());
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
            // 타겟이 플레이어만 캐스팅합니다.
            if (hit.transform.tag == "Player")
            {
                // 무기 데이터를 가져옵니다.
                if (weaponData != null && weaponData.weaponInfo != null)
                    weaponData.weaponInfo = hit.transform.GetComponentInChildren<WeaponController>()?.Data;

                // 캐스팅 데이터에 타겟을 저장하고 타겟을 표시합니다.
                if (castingData != null)
                {
                    castingData.target = hit.transform.gameObject;

                    if (!castingSignObj.activeSelf) castingSignObj.SetActive(true);

                    castingSignObj.transform.parent = hit.transform;
                    castingSignObj.transform.localPosition = new Vector3(0, 0, 0);
                }
            }

            // 캐스팅 타겟이 존재하면 이동할 포지션을 정합니다.
            if (castingData.target) castingData.target.GetComponent<ICastingPosition>().setPos(hit.point);
        }
    }

}
