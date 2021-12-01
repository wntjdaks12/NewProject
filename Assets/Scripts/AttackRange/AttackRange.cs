using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ݴϴ�.
/// </summary>
public class AttackRange : MonoBehaviour
{
    private void Start()
    {
        // �ӽ� ������
        Radius = 5 * 2;
    }

    // ������ Y ���� ������ŵ�ϴ�.
    private Vector3 Position { set { transform.position = value; } }

    /// <summary>
    /// ���� �������� �����մϴ�.
    /// </summary>
    public float Radius { set { transform.localScale = new Vector3(value, 0.5f, value); } }
}
