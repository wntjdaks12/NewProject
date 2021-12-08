using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ü Ʈ������ �������Դϴ�.
/// </summary>
public class ProjectileTrail : MonoBehaviour
{
    /// <summary>
    /// Ʈ������ �����ð��Դϴ�.
    /// </summary>
    public float keepTime;

    // ������ �ֻ��� ��ü�Դϴ�.
    private Transform parent;

    private void Start()
    {
        parent = transform.root;
    }

    /// <summary>
    /// Ʈ������ ������ŵ�ϴ�.
    /// </summary>
    public void Keep()
    {
        transform.parent = null;

        // �����ð��� ���� Ʈ������ ��Ȱ��ȭ��ŵ�ϴ�.
        Invoke("Destroy", keepTime);
    }

    /// <summary>
    /// Ʈ������ ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Destroy() 
    {
        // ���� ��ü�� ��Ӱ��踦 �����մϴ�.
        transform.parent = parent;
    }
}
