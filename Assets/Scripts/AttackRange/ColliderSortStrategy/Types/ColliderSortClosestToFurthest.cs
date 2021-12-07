using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 가장 가까운 곳에서 가장 먼 곳까지의 순서를 정렬해 주는 배치 행위자입니다.
/// </summary>
public class ColliderSortClosestToFurthest : ColliderSortBehaviour
{
    /// <summary>
    /// 콜라이더들을 재배치합니다.
    /// </summary>
    /// <param name="position">기준점</param>
    /// <param name="colliders">재배치할 콜라이더 리스트</param>
    /// <returns></returns>
    public List<Collider> Sort(Vector3 position, List<Collider> colliders)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            for (int j = i + 1; j < colliders.Count; j++)
            {
                // 기준점에서 콜라이더까지의 거리를 구합니다. ----------------------------------
                var val1 = (position - colliders[i].transform.position).sqrMagnitude;
                var val2 = (position - colliders[j].transform.position).sqrMagnitude;
                // ---------------------------------------------------------------------------

                // 가까운 곳부터 먼 곳까지의 순서로 정렬합니다. -------------------
                if (val1 < val2)
                {
                    var temp = colliders[i];
                    colliders[i] = colliders[j];
                    colliders[j] = colliders[i];
                }
                // -------------------------------------------------------------
            }
        }
        return colliders;
    }
}
