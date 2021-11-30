using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 입니다.
/// </summary>
public class Player : MonoBehaviour
{
    // 물리 제어를 위해 가져옵니다.
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>() ?? GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 플레이어를 가만히 있게 합니다.
    /// </summary>
    public void Idle()
    { 
    }

    /// <summary>
    /// 플레이어를 이동시킵니다.
    /// </summary>
    /// <param name="pos">이동 </param>
    /// <param name="spd">플레이어 속도</param>
    public void Move(Vector2 rotation, float speed)
    {
        // 퍼사드 패턴
        Direction(rotation);
        ForwardMove(speed);
    }

    // 이동 방향을 정해줍니다.
    private void Direction(Vector2 rotation)
    {
        var vec3 = new Vector3(rotation.x, rotation.y, 0) - Vector3.forward;
        
        transform.rotation = Quaternion.Euler(0, - Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg + 90, 0);
    }
    
    // 직선 이동을 합니다.
    private void ForwardMove(float speed)
    {
        if(rigid)
            rigid.velocity =  transform.forward * speed * Time.deltaTime;
    }
}
