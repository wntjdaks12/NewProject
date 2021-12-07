using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� �ݶ��̴��� ���ġ�� �ִ� �������Դϴ�.
/// </summary>
/// 
public interface ColliderSortBehaviour
{
    /// <summary>
    /// �ݶ��̴����� ���ġ�մϴ�.
    /// </summary>
    /// <param name="position">������</param>
    /// <param name="colliders">���ġ�� �ݶ��̴� ����Ʈ</param>
    /// <returns></returns>
    public List<Collider> Sort(Vector3 position, List<Collider> colliders);
}
