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

    // ĳ������ ǥ���� ������Ʈ�Դϴ�.
    [SerializeField]
    private GameObject castingSignObj;

    private void Start()
    {
        castingSignObj = Instantiate(castingSignObj);
        castingSignObj.SetActive(false);

        // 0.3�� ���� ����Ŭ���� �� �� ĳ������ �մϴ�.
        var clickStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));

        clickStream
            .Timestamp()
            .Pairwise((prev, cur) => (cur. Timestamp - prev.Timestamp).TotalMilliseconds <= 300)
            .Where(fastEnough => fastEnough)
            .Subscribe(x => Casting());
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
            // Ÿ���� �÷��̾ ĳ�����մϴ�.
            if (hit.transform.tag == "Player")
            {
                // ���� �����͸� �����ɴϴ�.
                if (weaponData != null && weaponData.weaponInfo != null)
                    weaponData.weaponInfo = hit.transform.GetComponentInChildren<WeaponController>()?.Data;

                // ĳ���� �����Ϳ� Ÿ���� �����ϰ� Ÿ���� ǥ���մϴ�.
                if (castingData != null)
                {
                    castingData.target = hit.transform.gameObject;

                    if (!castingSignObj.activeSelf) castingSignObj.SetActive(true);

                    castingSignObj.transform.parent = hit.transform;
                    castingSignObj.transform.localPosition = new Vector3(0, 0, 0);
                }
            }

            // ĳ���� Ÿ���� �����ϸ� �̵��� �������� ���մϴ�.
            if (castingData.target) castingData.target.GetComponent<ICastingPosition>().setPos(hit.point);
        }
    }

}
