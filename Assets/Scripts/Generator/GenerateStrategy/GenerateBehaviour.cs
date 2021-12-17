using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체를 다양한 방식으로 생성해 주는 행위자입니다.
/// </summary>
/// 
public interface GenerateBehaviour
{
    /// <summary>
    /// 생성 위치를 위치 값을 계산합니다.
    /// </summary>
    /// <param name="vec3">기준 정점</param>
    /// <param name="size">기준 정점으로부터 크기</param>
    /// <returns>생성시킬 위치를 리턴합니다.</returns>
    public Vector3 getGenerate(Vector3 vec3, float size);
}
