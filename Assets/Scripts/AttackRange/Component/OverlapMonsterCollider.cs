using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 박스만 체크하는 공격 범위 콜라이더입니다.
/// </summary>
public class OverlapMonsterCollider : MonoBehaviour
{
    /// <summary>
    /// 충돌 대리자입니다.
    /// </summary>
    public delegate void CollisionDelegate();

    /// <summary>
    /// 충돌 시작 시 이벤트입니다.
    /// </summary>
    public static event CollisionDelegate collisionEnterEvent;
    /// <summary>
    /// 충돌 끝날 시 이벤트입니다.
    /// </summary>
    public static event CollisionDelegate collisionExitEvent;

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
            // 충돌한 몬스터 수입니다
            var count = 0;

            for (int i = 0; i < colls.Length; i++)
            {
                // 충돌 시 몬스터가 있을 경우 이벤트를 실행합니다.
                if (colls[i].tag == "Monster")
                { 
                    collisionEnterEvent?.Invoke();

                    count++;
                }

                // 충돌 시 몬스터가 없을 경우 이벤트를 실행합니다.
                if (colls.Length - 1 == i && count == 0)
                    collisionExitEvent?.Invoke();
            }
        }
    }

    private void OnDisable()
    {
        collisionExitEvent?.Invoke();
    }
}
