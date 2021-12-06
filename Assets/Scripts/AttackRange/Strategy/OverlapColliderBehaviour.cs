using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� �ݶ��̴��� �Ǻ��ϴ� �������Դϴ�.
/// </summary>
public abstract class OverlapColliderBehaviour
{
    // �Ǻ��� �ݶ��̴����Դϴ�.
    protected List<Collider> colliders;

    public OverlapColliderBehaviour()
    {
        colliders = new List<Collider>();
    }

    /// <summary>
    /// �ݶ��̴����� �����մϴ�.
    /// </summary>
    /// <param name="position">���� ������ ��ü</param>
    /// <param name="radius">�ݰ�</param>
    public abstract void Extract(Vector3 position, float radius);

    /// <summary>
    /// �Ǻ��� �ݶ��̴����Դϴ�.
    /// </summary>
    public List<Collider> Colliders { get { return colliders; } }
}
