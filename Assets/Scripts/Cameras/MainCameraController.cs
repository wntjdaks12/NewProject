using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ī�޶� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MainCameraController : MonoBehaviour
{
    /// <summary>
    /// ������ �Ǵ� ����Դϴ�.
    /// </summary>
    public GameObject standardObject;

    // ���� ������ �Ÿ��� �����ϴ� �����Դϴ�
    [SerializeField]
    private Vector3 point;

    public void LateUpdate()
    {
        // �̵��մϴ�.
        Move();
    }

    // �̵��մϴ�.
    private void Move()
    {
        // �� üũ ------------------------------------------
        if (!standardObject)
            return;
        // -------------------------------------------------

        // ����� ��ġ�� �������� �̿��Ͽ� ������ �Ÿ��� �����մϴ�.
        transform.position = standardObject.transform.position + point;
    }
}
