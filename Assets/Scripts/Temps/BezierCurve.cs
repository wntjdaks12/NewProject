using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3차 베지어 곡선입니다.
/// </summary>
public class BezierCurve
{
    /// <summary>
    ///  베지어 곡선의 정점들입니다.
    /// </summary>
    public Vector3 p0, p1, p2, p3 = Vector3.zero;

    /// <summary>
    /// 선형보간을 이용하여 베지어 곡선입니다.
    /// </summary>
    /// <param name="time">0 ~ 1사이의 시간 값</param>
    /// <returns>시간에 맞는 정점을 리턴합니다.</returns>
    public Vector3 getValueOfTime(float time)
    {
        // 선형보간을 위해 0 ~ 1의 범위를 지정합니다.
        time = Mathf.Clamp(time, 0, 1);


        // p0, p1와 p2, p3의 선형보간의 결과값에 다시 선형보간을 하여 수식을 나타냅니다. -----------
        var u = 1.0f - time;
        var t2 = time * time;
        var u2 = u * u;
        var u3 = u2 * u;
        var t3 = t2 * time;

        Vector3 result =
            u3 * p0 +
            (3.0f * u2 * time) * p1 +
            (3.0f * u * t2) * p2 +
            t3 * p3;
        // ---------------------------------------------------------------------------------------

        return result;
    }
}
