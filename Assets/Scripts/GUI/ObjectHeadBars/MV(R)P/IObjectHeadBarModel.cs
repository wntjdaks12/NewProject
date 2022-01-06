using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ʈ ��ܿ� �����͸� �����ִ� �κ��Դϴ�.
/// </summary>
public interface IObjectHeadBarModel
{
    /// <summary>
    /// ������Ʈ�� �����Դϴ�.
    /// </summary>
    /// <returns>������ �����մϴ�.</returns>
    public int getLv();

    /// <summary>
    /// ������Ʈ�� ü���Դϴ�.
    /// </summary>
    /// <returns>ü���� �����մϴ�.</returns>
    public int getHp();

    /// <summary>
    /// ������Ʈ �ִ� ü���Դϴ�.
    /// </summary>
    /// <returns>���� ü���� �����մϴ�.</returns>
    public int getMaaxHp();
}
