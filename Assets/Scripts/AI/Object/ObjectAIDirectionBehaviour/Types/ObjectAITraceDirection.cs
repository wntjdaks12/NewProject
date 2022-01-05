using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 대상을 추적하는 방향 행위자입니다.
/// </summary>
public class ObjectAITraceDirection : ObjectAIDirectionBehaviour
{
    // 추적을 하기 위해 대상이 필요합니다.
    private GameObject target;

    public ObjectAITraceDirection(GameObject target) => this.target = target;

    /// <summary>
    /// 진행 할 방향을 가져옵니다.
    /// </summary>
    /// <param name="position">기준 위치 값</param>
    /// <returns>진행 방향을 리턴합니다.</returns>
    public Vector3 getDirection(Vector3 position)
    {
        // 이동할 위치과 기준 위치을 이용하여 방향을 구합니다.
        return target != null ? target.transform.position - position : Vector3.zero;
    }
}
