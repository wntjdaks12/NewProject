using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 투사체의 공격을 정해주는 행위자입니다.
/// </summary>
public abstract class ProjectileAttackBehaviour : MonoBehaviour
{
    // 해당 투사체입니다.
    protected Projectile projectile;

    // 해당 투사체입니다.
    public Projectile Projectile { set => projectile = value; }
}
