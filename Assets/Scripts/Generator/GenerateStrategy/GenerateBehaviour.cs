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
    /// 생성 위치를 가져옵니다.
    /// </summary>
    /// <param name="vec3">기준 정점</param>
    /// <param name="size">기준 정점으로부터 크기</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 vec3, float size);
}
