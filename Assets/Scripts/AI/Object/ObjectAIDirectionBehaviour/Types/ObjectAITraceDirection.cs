using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� �����ϴ� ���� �������Դϴ�.
/// </summary>
public class ObjectAITraceDirection : ObjectAIDirectionBehaviour
{
    // ������ �ϱ� ���� ����� �ʿ��մϴ�.
    private GameObject target;

    public ObjectAITraceDirection(GameObject target)
    {
        this.target = target;
    }

    /// <summary>
    /// ���� �� ������ �����ɴϴ�.
    /// </summary>
    /// <param name="position">���� ��ġ ��</param>
    /// <returns>���� ������ �����մϴ�.</returns>
    public Vector3 getDirection(Vector3 position)
    {
        // �̵��� ��ġ�� ���� ��ġ�� �̿��Ͽ� ������ ���մϴ�. ------
        if(target)
           return target.transform.position - position;
        // --------------------------------------------------------

        return Vector3.zero;
    }
}
