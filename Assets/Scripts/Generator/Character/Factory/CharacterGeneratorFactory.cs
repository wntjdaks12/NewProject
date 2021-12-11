using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터의 생성자입니다.
/// </summary>
public class CharacterGeneratorFactory
{
    /// <summary>
    /// 생성하려는 개체의 종류입니다.
    /// </summary>
    public enum Types {None, Player, Monster}

    /// <summary>
    /// 생성합니다.
    /// </summary>
    /// <param name="type">생성 개체 종류</param>
    /// <returns>생성하려는 개체의 인스턴스를 리턴합니다.</returns>
    public ICharacterGenerator Create(Types type)
    {
        // 생성하려는 개체와 맞는 인스턴스를 리턴합니다. ------------------------
        switch (type)
        {
            case Types.Player: return new PlayerGenerator();
            case Types.Monster: return new MonsterGenerator();
        }

        return null;
        // -------------------------------------------------------------------
    }
}
