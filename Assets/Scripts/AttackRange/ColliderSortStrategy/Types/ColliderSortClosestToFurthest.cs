using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ����� ������ ���� �� �������� ������ ������ �ִ� ��ġ �������Դϴ�.
/// </summary>
public class ColliderSortClosestToFurthest : ColliderSortBehaviour
{
    /// <summary>
    /// �ݶ��̴����� ���ġ�մϴ�.
    /// </summary>
    /// <param name="position">������</param>
    /// <param name="colliders">���ġ�� �ݶ��̴� ����Ʈ</param>
    /// <returns></returns>
    public List<Collider> Sort(Vector3 position, List<Collider> colliders)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            for (int j = i + 1; j < colliders.Count; j++)
            {
                // ���������� �ݶ��̴������� �Ÿ��� ���մϴ�. ----------------------------------
                var val1 = (position - colliders[i].transform.position).sqrMagnitude;
                var val2 = (position - colliders[j].transform.position).sqrMagnitude;
                // ---------------------------------------------------------------------------

                // ����� ������ �� �������� ������ �����մϴ�. -------------------
                if (val1 < val2)
                {
                    var temp = colliders[i];
                    colliders[i] = colliders[j];
                    colliders[j] = colliders[i];
                }
                // -------------------------------------------------------------
            }
        }
        return colliders;
    }
}
