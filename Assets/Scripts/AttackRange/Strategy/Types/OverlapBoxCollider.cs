using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 박스를 판별하는 공격 범위 행위자입니다.
/// </summary>
public class OverlapBoxCollider : OverlapColliderBehaviour  
{
    /// <summary>
    /// 콜라이더들을 추출합니다.
    /// </summary>
    /// <param name="position">공격 범위의 주체</param>
    /// <param name="radius">반경</param>
    public override void Extract(Vector3 position, float radius)
    {
        // 판별한 콜라이더 리스트를 초기화합니다.
        colliders.Clear();

        // 공격 범위를 설정합니다.
        var colls = Physics.OverlapSphere(position, radius);

        // 박스인 콜라이더만 판별합니다.
        if (colls.Length > 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                if (colls[i].tag == "Box")
                    colliders.Add(colls[i]);
            }
        }
    }
}
