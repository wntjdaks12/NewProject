using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 베지어 곡선을 이용한 인공 지능 방향 행위자입니다.
/// </summary>
public class ObjectAIBezierCurveDirection : ObjectAIDirectionBehaviour
{ 
    // 베지어 곡선의 정보를 알기 위해 인공 지능을 가져옵니다.
    private ObjectAI objectAI;

    public ObjectAIBezierCurveDirection(ObjectAI objectAI)
    {
        this.objectAI = objectAI;
    }

    /// <summary>
    /// 진행 할 방향을 가져옵니다.
    /// </summary>
    /// <param name="position">기준 위치 값</param>
    /// <returns>진행 방향을 리턴합니다.</returns>
    public Vector3 getDirection(Vector3 position)
    {
        // 이동할 위치과 기준 위치을 이용하여 방향을 구합니다. -------------------------
        if(objectAI)
            if (objectAI.Points != null)
                return objectAI.Points[objectAI.CurPartIndex] - position;
        // --------------------------------------------------------------------------

        return Vector3.zero;
    }
}
