using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 무기는 Weapon을 상속받습니다.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// 공격합니다.
    /// </summary>
    public abstract void Attack();
}
