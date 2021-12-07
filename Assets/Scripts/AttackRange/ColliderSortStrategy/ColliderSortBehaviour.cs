using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 범위 콜라이더를 재배치해 주는 행위자입니다.
/// </summary>
/// 
public interface ColliderSortBehaviour
{
    /// <summary>
    /// 콜라이더들을 재배치합니다.
    /// </summary>
    /// <param name="position">기준점</param>
    /// <param name="colliders">재배치할 콜라이더 리스트</param>
    /// <returns></returns>
    public List<Collider> Sort(Vector3 position, List<Collider> colliders);
}
