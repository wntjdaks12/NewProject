using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڽ��� üũ�ϴ� ���� ���� �ݶ��̴��Դϴ�.
/// </summary>
public class OverlapMonsterCollider : MonoBehaviour
{
    /// <summary>
    /// �浹 �븮���Դϴ�.
    /// </summary>
    public delegate void CollisionDelegate();

    /// <summary>
    /// �浹 ���� �� �̺�Ʈ�Դϴ�.
    /// </summary>
    public static event CollisionDelegate collisionEnterEvent;
    /// <summary>
    /// �浹 ���� �� �̺�Ʈ�Դϴ�.
    /// </summary>
    public static event CollisionDelegate collisionExitEvent;

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
            // �浹�� ���� ���Դϴ�
            var count = 0;

            for (int i = 0; i < colls.Length; i++)
            {
                // �浹 �� ���Ͱ� ���� ��� �̺�Ʈ�� �����մϴ�.
                if (colls[i].tag == "Monster")
                { 
                    collisionEnterEvent?.Invoke();

                    count++;
                }

                // �浹 �� ���Ͱ� ���� ��� �̺�Ʈ�� �����մϴ�.
                if (colls.Length - 1 == i && count == 0)
                    collisionExitEvent?.Invoke();
            }
        }
    }

    private void OnDisable()
    {
        collisionExitEvent?.Invoke();
    }
}
