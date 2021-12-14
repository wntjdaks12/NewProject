using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 체력 관련 시스템입니다.
/// </summary>
public class HealthSystem
{
    /// <summary>
    /// 데미지를 입힙니다.
    /// </summary>
    /// <param name="hp">현재 체력</param>
    /// <param name="maxHp">현재 최대 체력</param>
    /// <param name="damage">데미지</param>
    /// <returns></returns>
    public static int Damage(int hp, int maxHp, int damage)
    {
        //  현재 체력에서 데미지를 빼고 최소 체력은 0으로 합니다. -----------
        var curHp = hp - damage;

        if (curHp < 0)
            curHp = 0;
        // ----------------------------------------------------------------

        return curHp;
    }
}
