using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 범위 및 콜라이더들을 판단합니다.
/// </summary>
public class AttackRange : MonoBehaviour
{
    // 여러방식의 콜라이더 추출을 위해 유연하게 변경하는 행위자입니다.
    private OverlapColliderBehaviour overlapColliderBehaviour;

    //  콜라이더들의 순서를 유연하게 재배치하기 위한 행위자입니다.
    private ColliderSortBehaviour colliderSortBehaviour;

    // 공격 범위를 나타내는 주체입니다. 
    private GameObject target;

    private void Awake()
    {
        overlapColliderBehaviour = new OverlapMonsterCollider();

        colliderSortBehaviour = new ColliderSortClosestToFurthest();
    }

    /// <summary>
    /// 범위 내 콜라이더의 존재 여부를 판단합니다.
    /// </summary>
    /// <returns>존재 여부를 리턴합니다.</returns>
    public bool CheckColliders()
    {
        if (overlapColliderBehaviour == null)
            return false;

        // 범위 내 콜라이더가 0개일 경우 콜라이더는 없습니다.
        if (overlapColliderBehaviour.Colliders.Count == 0)
            return false;

        return true;
    }

    /// <summary>
    /// 공격 범위를 활성화시킵니다.
    /// </summary>
    /// <param name="target">공격 범위의 주체</param>
    /// <param name="radius">반경</param>
    public void Active(GameObject target, float radius)
    {
        Target = target;

        Radius = radius;
    }

    /// <summary>
    /// 공격 범위를 비활성화시킵니다.
    /// </summary>
    public void Deactive()
    {
        Target = null;

        Radius = 0;
    }

    /// <summary>
    /// 공격 범위를 작동시킵니다.
    /// </summary>
    public void Operate()
    {
        if (!target)
            return;

        // 공격 범위의 주체와 반경을 사용하여 행위에 맞는 콜라이더들을 추출합니다.
        overlapColliderBehaviour.Extract(target.transform.position, transform.localScale.x * 0.5f);

        // 공격 범위의 위치를 설정합니다.
        transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
    }

    /// <summary>
    /// 충돌된 콜라이더들입니다.
    /// </summary>
    /// <returns>충돌된 콜라이더들을 리턴합니다.</returns>
    public List<Collider> GetColliders()
    {
        // 충돌된 콜라이더들의 순서를 재배치합니다.
        colliderSortBehaviour.Sort(transform.position, overlapColliderBehaviour.Colliders);

        return overlapColliderBehaviour.Colliders;
    }

    private void FixedUpdate()
    {
        Operate();
    }

    /// <summary>
    /// 공격 범위의 주체입니다.
    /// </summary>
    public GameObject Target { set { target = value; } }

    /// <summary>
    /// 공격 범위의 반경입니다.
    /// </summary>
    public float Radius { set { transform.localScale = new Vector3(value, 0.5f, value); } }

    /// <summary>
    /// 공격 범위의 행위자입니다.
    /// </summary>
    public OverlapColliderBehaviour OverlapColliderBehaviour { set { overlapColliderBehaviour = value; } }

    /// <summary>
    /// 공격 범위 안의 콜라이더들을 재배치해 주는 행위자입니다.
    /// </summary>
    public ColliderSortBehaviour ColliderSortBehaviour { set { colliderSortBehaviour = value; } }
}