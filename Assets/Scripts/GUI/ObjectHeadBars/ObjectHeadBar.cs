using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��� ���Դϴ�.
public class ObjectHeadBar : MonoBehaviour
{
    // ��� �� �̵��� ���� ��Ʈ Ʈ�������� �����ɴϴ�.
    private RectTransform rt;

    private void Awake() => rt = GetComponent<RectTransform>();

    //��� �ٸ� �̵���ŵ�ϴ�.
    public void Move(Vector3 vec3)
    {
        if (rt != null) rt.position = vec3;
    }
}