using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 투사체 트레일을 제어자입니다.
/// </summary>
public class ProjectileTrail : MonoBehaviour
{
    /// <summary>
    /// 트레일의 유지시간입니다.
    /// </summary>
    public float keepTime;

    // 관계의 최상위 개체입니다.
    private Transform parent;

    private void Start()
    {
        parent = transform.root;
    }

    /// <summary>
    /// 트레일을 유지시킵니다.
    /// </summary>
    public void Keep()
    {
        transform.parent = null;

        // 유지시간에 맞춰 트레일을 비활성화시킵니다.
        Invoke("Destroy", keepTime);
    }

    /// <summary>
    /// 트레일을 비활성화시킵니다.
    /// </summary>
    public void Destroy() 
    {
        // 본래 개체의 상속관계를 유지합니다.
        transform.parent = parent;
    }
}
