using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 자동 사냥 버튼 상태를 캡슐화한 인터페이스입니다.
/// </summary>
public interface AutoHuntingBtnState
{
    /// <summary>
    /// 활성화 상태입니다.
    /// </summary>
    /// <param name="btn">버튼 주솟값</param>
    public void On(AutoHuntingBtnPresenter btn);

    /// <summary>
    /// 비활성화 상태입니다.
    /// </summary>
    /// <param name="btn">버튼 주솟값</param>
    public void Off(AutoHuntingBtnPresenter btn);
}
