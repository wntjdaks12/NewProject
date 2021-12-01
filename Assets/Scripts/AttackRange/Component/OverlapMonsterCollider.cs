using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 박스만 체크하는 공격 범위 콜라이더입니다.
/// </summary>
public class OverlapMonsterCollider : MonoBehaviour
{
    private void FixedUpdate()
    {
        // 임시데이터
        CheckCollider(5);
    }

    // 범위 내 해당 콜라이더를 체크합니다.
    private void CheckCollider(float radius)
    {
        // 충돌 범위를 설정합니다.
        var colls = Physics.OverlapSphere(transform.position, radius);

        // 콜라이더가 몬스터일 경우만 체크합니다.
        if (colls.Length > 0)
        {
            foreach (Collider coll in colls)
            {
                if (coll.tag == "Monster")
                {

                }
            }
        }
    }
}
