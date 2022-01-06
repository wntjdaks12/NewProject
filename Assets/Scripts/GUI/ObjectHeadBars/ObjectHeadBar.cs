using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 상단 바입니다.
public class ObjectHeadBar : MonoBehaviour
{
    // 상단 바 이동을 위해 렉트 트랜스폼을 가져옵니다.
    private RectTransform rt;

    private void Awake() => rt = GetComponent<RectTransform>();

    //상단 바를 이동시킵니다.
    public void Move(Vector3 vec3)
    {
        if (rt != null) rt.position = vec3;
    }
}