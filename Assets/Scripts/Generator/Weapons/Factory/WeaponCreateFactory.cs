using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기 생성자입니다.
/// </summary>
public class WeaponCreateFactory : MonoBehaviour
{
    /// <summary>
    /// 생성하려는 개체의 종류입니다.
    /// </summary>
    public enum Types {None, Pistol, Buster, Cannon}

    // <summary>
    /// 생성합니다.

    /// </summary>
    /// <param name="type">생성 개체 종류</param>
    /// <returns>생성하려는 개체의 인스턴스를 리턴합니다.</returns>
    public IWeaponGenerator Create(Types type)
    {
        // 생성하려는 개체와 맞는 인스턴스를 리턴합니다. ------------------------
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
