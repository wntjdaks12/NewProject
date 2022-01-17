using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڵ� ��� ��ư ������ ��Ȱ��ȭ �κ��Դϴ�.
/// </summary>
public class AutoHuntingBtnOffState : AutoHuntingBtnState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static AutoHuntingBtnOffState instance = new AutoHuntingBtnOffState();

    /// <summary>
    /// ��Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void Off(AutoHuntingBtnPresenter btn) { }

    /// <summary>
    /// Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void On(AutoHuntingBtnPresenter btn)
    {
        // ��ư �̹��� ���� �����մϴ�.
        var col = btn.Img.color;
        btn.Img.color = new Color(col.r, col.g, col.b, 1);

        // Ȱ��ȭ ���·� �����մϴ�.
        btn.State = AutoHuntingBtnOnState.Instance;
    }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static AutoHuntingBtnOffState Instance { get { return instance; } }
}
