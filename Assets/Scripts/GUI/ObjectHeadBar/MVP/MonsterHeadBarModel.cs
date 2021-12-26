using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 오브젝트 상단에 몬스터 데이터를 보여주는 부분입니다.
/// </summary>
public class MonsterHeadBarModel : IObjectHeadBarModel
{
    private MonsterData monsterData;

    public MonsterData MonsterData { set => monsterData = value; }

    public int getHp()
    {
        if(monsterData != null && monsterData.Data != null)
            return monsterData.Data.hp;
        return 0;
    }

    public int getLv()
    {
        if (monsterData != null && monsterData.Data != null)
            return monsterData.Data.lv;
        return 0;
    }

    public int getMaaxHp()
    {
        if (monsterData != null && monsterData.Data != null)
            return monsterData.Data.maxHp;
        return 0;
    }
}
