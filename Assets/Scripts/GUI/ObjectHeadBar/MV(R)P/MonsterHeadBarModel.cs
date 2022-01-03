using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ��ܿ� ���� �����͸� �����ִ� �κ��Դϴ�.
/// </summary>
public class MonsterHeadBarModel : IObjectHeadBarModel
{
    private MonsterData monsterData;

    public MonsterData MonsterData { set => monsterData = value; }

    /// <summary>
    /// ������Ʈ�� ü���Դϴ�.
    /// </summary>
    /// <returns>ü���� �����մϴ�.</returns>
    public int getHp()
    {
        if(monsterData != null && monsterData.Data != null)
            return monsterData.Data.hp;
        return 0;
    }

    /// <summary>
    /// ������Ʈ�� �����Դϴ�.
    /// </summary>
    /// <returns>������ �����մϴ�.</returns>
    public int getLv()
    {
        if (monsterData != null && monsterData.Data != null)
            return monsterData.Data.lv;
        return 0;
    }

    /// <summary>
    /// ������Ʈ �ִ� ü���Դϴ�.
    /// </summary>
    /// <returns>���� ü���� �����մϴ�.</returns>
    public int getMaaxHp()
    {
        if (monsterData != null && monsterData.Data != null)
            return monsterData.Data.maxHp;
        return 0;
    }
}
