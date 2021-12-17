using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체의 생성 방식 중 정사각형의 내에서 생성하는 부분입니다.
/// </summary>
/// 
public class SquareGenerate : GenerateBehaviour
{
    /// <summary>
    /// 생성 위치를 위치 값을 계산합니다.
    /// </summary>
    /// <param name="vec3">기준 정점</param>
    /// <param name="size">기준 정점으로부터 크기</param>
    /// <returns>생성시킬 위치를 리턴합니다.</returns>
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
