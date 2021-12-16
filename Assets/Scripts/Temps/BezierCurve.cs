using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 3�� ������ ��Դϴ�.
/// </summary>
public class BezierCurve
{
    /// <summary>
    ///  ������ ��� �������Դϴ�.
    /// </summary>
    public Vector3 p0, p1, p2, p3 = Vector3.zero;

    /// <summary>
    /// ���������� �̿��Ͽ� ������ ��Դϴ�.
    /// </summary>
    /// <param name="time">0 ~ 1������ �ð� ��</param>
    /// <returns>�ð��� �´� ������ �����մϴ�.</returns>
    public Vector3 getValueOfTime(float time)
    {
        // ���������� ���� 0 ~ 1�� ������ �����մϴ�.
        time = Mathf.Clamp(time, 0, 1);


        // p0, p1�� p2, p3�� ���������� ������� �ٽ� ���������� �Ͽ� ������ ��Ÿ���ϴ�. -----------
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
