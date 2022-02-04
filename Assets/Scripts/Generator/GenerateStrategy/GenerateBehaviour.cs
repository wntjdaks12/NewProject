using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� �پ��� ������� ������ �ִ� �������Դϴ�.
/// </summary>
/// 
public interface GenerateBehaviour
{
    /// ���� ��ġ�� ��ġ ���� ����մϴ�.
    /// </summary>
    /// <param name="pos">������</param>
    /// <param name="radius">�ݰ�</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 pos, float radius);
}
