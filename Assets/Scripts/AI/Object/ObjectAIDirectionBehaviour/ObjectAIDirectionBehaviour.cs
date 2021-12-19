using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 인공 지능 방향을 정해주는 행위자입니다.
/// </summary>
public interface ObjectAIDirectionBehaviour
{
    /// <summary>
    /// 진행 할 방향을 가져옵니다.
    /// </summary>
    /// <param name="position">기준 위치 값</param>
    /// <returns>진행 방향을 리턴합니다.</returns>
    public Vector3 getDirection(Vector3 position);
}
