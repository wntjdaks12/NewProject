using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾� �������Դϴ�.
/// </summary>
[CreateAssetMenu(fileName = "Player Data")]
public class PlayerData : ScriptableObject
{
    private float speed;

    /// <summary>
    /// �̵� �ӵ� ���Դϴ�.
    /// </summary>
    public float Speed { get { return speed; } set { speed = value; } }
}
