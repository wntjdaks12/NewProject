using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ĳ������ �������Դϴ�.
/// </summary>
public class CharacterGeneratorFactory
{
    /// <summary>
    /// �����Ϸ��� ��ü�� �����Դϴ�.
    /// </summary>
    public enum Types {None, Player, Monster}

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    /// <param name="type">���� ��ü ����</param>
    /// <returns>�����Ϸ��� ��ü�� �ν��Ͻ��� �����մϴ�.</returns>
    public ICharacterGenerator Create(Types type)
    {
        // �����Ϸ��� ��ü�� �´� �ν��Ͻ��� �����մϴ�. ------------------------
        switch (type)
        {
            case Types.Player: return new PlayerGenerator();
            case Types.Monster: return new MonsterGenerator();
        }

        return null;
        // -------------------------------------------------------------------
    }
}
