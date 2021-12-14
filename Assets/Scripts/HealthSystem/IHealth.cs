using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체의 헬스 부분을 캡슐화한 인터페이스입니다.
/// </summary>
public interface IHealth
{
    /// <summary>
    /// 데미지를 입습니다.
    /// </summary>
    /// <param name="damage">데미지 값</param>
    public void Damage(int damage);
}
