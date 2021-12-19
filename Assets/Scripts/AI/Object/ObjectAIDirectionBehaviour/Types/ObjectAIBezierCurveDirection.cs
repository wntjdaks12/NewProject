using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ��� �̿��� �ΰ� ���� ���� �������Դϴ�.
/// </summary>
public class ObjectAIBezierCurveDirection : ObjectAIDirectionBehaviour
{ 
    // ������ ��� ������ �˱� ���� �ΰ� ������ �����ɴϴ�.
    private ObjectAI objectAI;

    public ObjectAIBezierCurveDirection(ObjectAI objectAI)
    {
        this.objectAI = objectAI;
    }

    /// <summary>
    /// ���� �� ������ �����ɴϴ�.
    /// </summary>
    /// <param name="position">���� ��ġ ��</param>
    /// <returns>���� ������ �����մϴ�.</returns>
    public Vector3 getDirection(Vector3 position)
    {
        // �̵��� ��ġ�� ���� ��ġ�� �̿��Ͽ� ������ ���մϴ�. -------------------------
        if(objectAI)
            if (objectAI.Points != null)
                return objectAI.Points[objectAI.CurPartIndex] - position;
        // --------------------------------------------------------------------------

        return Vector3.zero;
    }
}
