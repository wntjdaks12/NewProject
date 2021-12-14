using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ü�� ���� �ý����Դϴ�.
/// </summary>
public class HealthSystem
{
    /// <summary>
    /// �������� �����ϴ�.
    /// </summary>
    /// <param name="hp">���� ü��</param>
    /// <param name="maxHp">���� �ִ� ü��</param>
    /// <param name="damage">������</param>
    /// <returns></returns>
    public static int Damage(int hp, int maxHp, int damage)
    {
        //  ���� ü�¿��� �������� ���� �ּ� ü���� 0���� �մϴ�. -----------
        var curHp = hp - damage;

        if (curHp < 0)
            curHp = 0;
        // ----------------------------------------------------------------

        return curHp;
    }
}
