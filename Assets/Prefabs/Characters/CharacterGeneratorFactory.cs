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
    public enum Types {None, Gunslinger, Buster, CannonShooter, UnName1}

    /// <summary>
    /// �����մϴ�.
    /// </summary>
    /// <param name="type">���� ��ü ����</param>
    /// <returns>�����Ϸ��� ��ü�� �ν��Ͻ��� �����մϴ�.</returns>
    public ICharacterGenerator Create(Types type)
    {
        // �����Ϸ��� ��ü�� �´� �ν��Ͻ��� �����մϴ�.
        switch (type)
        {
            case Types.Gunslinger: return new GunslingerChampGenerator();
            case Types.Buster: return new BusterChampGenerator();
            case Types.CannonShooter: return new CannonShooterChampGenerator();
            case Types.UnName1: return new UnName1Generator();
        }

        return null;
    }
}