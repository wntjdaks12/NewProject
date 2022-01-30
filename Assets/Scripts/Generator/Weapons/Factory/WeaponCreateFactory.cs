using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �������Դϴ�.
/// </summary>
public class WeaponCreateFactory : MonoBehaviour
{
    /// <summary>
    /// �����Ϸ��� ��ü�� �����Դϴ�.
    /// </summary>
    public enum Types {None, Pistol, Buster, Cannon}

    // <summary>
    /// �����մϴ�.

    /// </summary>
    /// <param name="type">���� ��ü ����</param>
    /// <returns>�����Ϸ��� ��ü�� �ν��Ͻ��� �����մϴ�.</returns>
    public IWeaponGenerator Create(Types type)
    {
        // �����Ϸ��� ��ü�� �´� �ν��Ͻ��� �����մϴ�. ------------------------
        switch (type)
        {
            case Types.Pistol: return new PistolGenerator();
            case Types.Buster: return new BusterGenerator();
            case Types.Cannon: return new CannonGenerator();
        }

        return null;
        // -------------------------------------------------------------------
    }
}
