using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ڵ� ��� ��ư ���¸� ĸ��ȭ�� �������̽��Դϴ�.
/// </summary>
public interface AutoHuntingBtnState
{
    /// <summary>
    /// Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void On(AutoHuntingBtnPresenter btn);

    /// <summary>
    /// ��Ȱ��ȭ �����Դϴ�.
    /// </summary>
    /// <param name="btn">��ư �ּڰ�</param>
    public void Off(AutoHuntingBtnPresenter btn);
}
