using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڽ��� �Ǻ��ϴ� ���� ���� �������Դϴ�.
/// </summary>
public class OverlapBoxCollider : OverlapColliderBehaviour  
{
    /// <summary>
    /// �ݶ��̴����� �����մϴ�.
    /// </summary>
    /// <param name="position">���� ������ ��ü</param>
    /// <param name="radius">�ݰ�</param>
    public override void Extract(Vector3 position, float radius)
    {
        // �Ǻ��� �ݶ��̴� ����Ʈ�� �ʱ�ȭ�մϴ�.
        colliders.Clear();

        // ���� ������ �����մϴ�.
        var colls = Physics.OverlapSphere(position, radius);

        // �ڽ��� �ݶ��̴��� �Ǻ��մϴ�.
        if (colls.Length > 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                if (colls[i].tag == "Box")
                    colliders.Add(colls[i]);
            }
        }
    }
}
