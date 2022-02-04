using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체를 다양한 방식으로 생성해 주는 행위자입니다.
/// </summary>
/// 
public interface GenerateBehaviour
{
    /// 생성 위치를 위치 값을 계산합니다.
    /// </summary>
    /// <param name="pos">기준점</param>
    /// <param name="radius">반경</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 pos, float radius);
}
