using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� �� �ݶ��̴����� �Ǵ��մϴ�.
/// </summary>
public class AttackRange : MonoBehaviour
{
    // ��������� �ݶ��̴� ������ ���� �����ϰ� �����ϴ� �������Դϴ�.
    private OverlapColliderBehaviour overlapColliderBehaviour;

    //  �ݶ��̴����� ������ �����ϰ� ���ġ�ϱ� ���� �������Դϴ�.
    private ColliderSortBehaviour colliderSortBehaviour;

    // ���� ������ ��Ÿ���� ��ü�Դϴ�. 
    private GameObject target;

    private void Awake()
    {
        overlapColliderBehaviour = new OverlapMonsterCollider();

        colliderSortBehaviour = new ColliderSortClosestToFurthest();
    }

    /// <summary>
    /// ���� ������ Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="target">���� ������ ��ü</param>
    /// <param name="radius">�ݰ�</param>
    public void Active(GameObject target, float radius)
    {
        Target = target;

        Radius = radius;
    }

    /// <summary>
    /// ���� ������ ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Deactive()
    {
        Target = null;

        Radius = 0;
    }

    /// <summary>
    /// ���� ������ �۵���ŵ�ϴ�.
    /// </summary>
    public void Operate()
    {
        if (!target)
            return;

        // ���� ������ ��ü�� �ݰ��� ����Ͽ� ������ �´� �ݶ��̴����� �����մϴ�.
        overlapColliderBehaviour.Extract(target.transform.position, transform.localScale.x * 0.5f);

        // ���� ������ ��ġ�� �����մϴ�.
        transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
    }

    private void FixedUpdate()
    {
        Operate();
    }

    /// <summary>
    /// ���� ������ ��ü�Դϴ�.
    /// </summary>
    public GameObject Target { set { target = value; } }

    /// <summary>
    /// ���� ������ �ݰ��Դϴ�.
    /// </summary>
    public float Radius { set { transform.localScale = new Vector3(value, 0.5f, value); } }

    /// <summary>
    /// ���� ������ �������Դϴ�.
    /// </summary>
    public OverlapColliderBehaviour OverlapBehaviour { get { return overlapColliderBehaviour; } }

    /// <summary>
    /// ���� ���� ���� �ݶ��̴����� ���ġ�� �ִ� �������Դϴ�.
    /// </summary>
    public ColliderSortBehaviour ColliderSortBehaviour { get { return colliderSortBehaviour; } }
}