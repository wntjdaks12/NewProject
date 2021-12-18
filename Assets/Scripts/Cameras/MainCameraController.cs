using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 메인 카메라를 제어하는 컨트롤러입니다.
/// </summary>
public class MainCameraController : MonoBehaviour
{
    /// <summary>
    /// 기준이 되는 대상입니다.
    /// </summary>
    public GameObject standardObject;

    // 기준 대상과의 거리를 유지하는 정점입니다
    [SerializeField]
    private Vector3 point;

    public void LateUpdate()
    {
        // 이동합니다.
        Move();
    }

    // 이동합니다.
    private void Move()
    {
        // 널 체크 ------------------------------------------
        if (!standardObject)
            return;
        // -------------------------------------------------

        // 대상의 위치와 기준점을 이용하여 대상과의 거리를 유지합니다.
        transform.position = standardObject.transform.position + point;
    }
}
