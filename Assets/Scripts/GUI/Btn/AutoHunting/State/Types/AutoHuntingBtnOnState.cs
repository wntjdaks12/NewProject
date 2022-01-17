using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڵ� ��� ��ư ������ Ȱ��ȭ �κ��Դϴ�.
/// </summary>
public class AutoHuntingBtnOnState : AutoHuntingBtnState
{
    // �ڽ� �ν��Ͻ� �Դϴ�.
    private static AutoHuntingBtnOnState instance = new AutoHuntingBtnOnState();

    /// <summary>
    /// ��Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void Off(AutoHuntingBtnPresenter btn)
    {
        // ��ư �̹��� ���� �����մϴ�.
        var col = btn.Img.color;
        btn.Img.color = new Color(col.r, col.g, col.b, 0.1f);

        // Ȱ��ȭ ���·� �����մϴ�.
        btn.State = AutoHuntingBtnOffState.Instance;
    }

    /// <summary>
    /// Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void On(AutoHuntingBtnPresenter btn) { }

    /// <summary>
    /// �ڽ� �ν��Ͻ� �Դϴ�.
    /// </summary>
    public static AutoHuntingBtnOnState Instance { get { return instance; } }
}
