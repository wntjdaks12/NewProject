using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڽ��� üũ�ϴ� ���� ���� �ݶ��̴��Դϴ�.
/// </summary>
public class OverlapMonsterCollider : MonoBehaviour
{
    private void FixedUpdate()
    {
        // �ӽõ�����
        CheckCollider(5);
    }

    // ���� �� �ش� �ݶ��̴��� üũ�մϴ�.
    private void CheckCollider(float radius)
    {
        // �浹 ������ �����մϴ�.
        var colls = Physics.OverlapSphere(transform.position, radius);

        // �ݶ��̴��� ������ ��츸 üũ�մϴ�.
        if (colls.Length > 0)
        {
            foreach (Collider coll in colls)
            {
                if (coll.tag == "Monster")
                {

                }
            }
        }
    }
}
