using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 범위 콜라이더를 판별하는 행위자입니다.
/// </summary>
public abstract class OverlapColliderBehaviour
{
    // 판별한 콜라이더들입니다.
    protected List<Collider> colliders;

    public OverlapColliderBehaviour()
    {
        colliders = new List<Collider>();
    }

    /// <summary>
    /// 콜라이더들을 추출합니다.
    /// </summary>
    /// <param name="position">공격 범위의 주체</param>
    /// <param name="radius">반경</param>
    public abstract void Extract(Vector3 position, float radius);

    /// <summary>
    /// 판별한 콜라이더들입니다.
    /// </summary>
    public List<Collider> Colliders { get { return colliders; } }
}
