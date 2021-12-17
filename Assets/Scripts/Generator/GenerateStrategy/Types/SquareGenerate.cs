using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� ���� ��� �� ���簢���� ������ �����ϴ� �κ��Դϴ�.
/// </summary>
/// 
public class SquareGenerate : GenerateBehaviour
{
    /// <summary>
    /// ���� ��ġ�� ��ġ ���� ����մϴ�.
    /// </summary>
    /// <param name="vec3">���� ����</param>
    /// <param name="size">���� �������κ��� ũ��</param>
    /// <returns>������ų ��ġ�� �����մϴ�.</returns>
    public Vector3 getGenerate(Vector3 vec3, float size)
    {
        var p0 = new Vector3(-size, 0, size);
        var p1 = new Vector3(size, 0, size);
        var p2 = new Vector3(size, 0, -size);
        var p3 = new Vector3(-size, 0, -size);

        var rand1 = Random.Range(p0.x, p1.x);
        var rand2 = Random.Range(p1.y, p2.y);

        return new Vector3(vec3.x + rand1, vec3.y, vec3.z + rand2);
    }
}
