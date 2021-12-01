using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 범위를 보여줍니다.
/// </summary>
public class AttackRange : MonoBehaviour
{
    private void Start()
    {
        // 임시 데이터
        Radius = 5 * 2;
    }

    private void Update()
    {
        Position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    // 포지션 Y 값을 고정시킵니다.
    private Vector3 Position { set { transform.position = value; } }

    /// <summary>
    /// 범위 반지름을 설정합니다.
    /// </summary>
    public float Radius { set { transform.localScale = new Vector3(value, 0.5f, value); } }
}
