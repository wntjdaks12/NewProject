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
    public int getHp() => monsterData == null ? 0 :
        monsterData.Data == null ? 0 : monsterData.Data.hp;

    /// <summary>
    /// ������Ʈ�� �����Դϴ�.
    /// </summary>
    /// <returns>������ �����մϴ�.</returns>
    public int getLv() => monsterData == null ? 0 :
        monsterData.Data == null ? 0 : monsterData.Data.lv;

    /// <summary>
    /// ������Ʈ �ִ� ü���Դϴ�.
    /// </summary>
    /// <returns>���� ü���� �����մϴ�.</returns>
    public int getMaaxHp() => monsterData == null ? 0 :
        monsterData.Data == null ? 0 : monsterData.Data.maxHp;
}
