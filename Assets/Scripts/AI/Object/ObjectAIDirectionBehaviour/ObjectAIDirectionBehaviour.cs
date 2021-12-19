using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ΰ� ���� ������ �����ִ� �������Դϴ�.
/// </summary>
public interface ObjectAIDirectionBehaviour
{
    /// <summary>
    /// ���� �� ������ �����ɴϴ�.
    /// </summary>
    /// <param name="position">���� ��ġ ��</param>
    /// <returns>���� ������ �����մϴ�.</returns>
    public Vector3 getDirection(Vector3 position);
}
