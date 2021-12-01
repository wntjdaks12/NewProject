using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��Դϴ�.
/// </summary>
public class Player : Character
{
    /// <summary>
    /// �÷��̾ ������ �ְ� �մϴ�.
    /// </summary>
    public void Idle()
    {
        // ������ �ִ� ���·� �����մϴ�.
        state.Idle(this);
    }

    /// <summary>
    /// �÷��̾ �̵���ŵ�ϴ�.
    /// </summary>
    /// <param name="pos">�̵� </param>
    /// <param name="spd">�÷��̾� �ӵ�</param>
    public void Move(Vector2 rotation, float speed)
    {
        // �̵� ���·� �����մϴ�.
        state.Move(this);

        // �ۻ�� ����
        Direction(rotation);
        ForwardMove(speed);
    }

    // �̵� ������ �����ݴϴ�.
    private void Direction(Vector2 rotation)
    {
        var vec3 = new Vector3(rotation.x, rotation.y, 0) - Vector3.forward;
        
        transform.rotation = Quaternion.Euler(0, - Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg + 90, 0);
    }
    
    // ���� �̵��� �մϴ�.
    private void ForwardMove(float speed)
    {
        if (rigid)
            rigid.velocity =  transform.forward * speed * Time.deltaTime;
    }
}
