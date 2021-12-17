using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� �پ��� ������� ������ �ִ� �������Դϴ�.
/// </summary>
/// 
public interface GenerateBehaviour
{
    /// <summary>
    /// ���� ��ġ�� �����ɴϴ�.
    /// </summary>
    /// <param name="vec3">���� ����</param>
    /// <param name="size">���� �������κ��� ũ��</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 vec3, float size);
}
