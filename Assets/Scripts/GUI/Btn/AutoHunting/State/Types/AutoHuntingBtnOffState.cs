using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 자동 사냥 버튼 상태중 비활성화 부분입니다.
/// </summary>
public class AutoHuntingBtnOffState : AutoHuntingBtnState
{
    // 자신 인스턴스 입니다.
    private static AutoHuntingBtnOffState instance = new AutoHuntingBtnOffState();

    /// <summary>
    /// 비활성화 상태입니다.
    /// </summary>
    /// <param name="btn">버튼 주솟값</param>
    public void Off(AutoHuntingBtnPresenter btn) { }

    /// <summary>
    /// 활성화 상태입니다.
    /// </summary>
    /// <param name="btn">버튼 주솟값</param>
    public void On(AutoHuntingBtnPresenter btn)
    {
        // 버튼 이미지 색을 변경합니다.
        var col = btn.Img.color;
        btn.Img.color = new Color(col.r, col.g, col.b, 1);

        // 활성화 상태로 변경합니다.
        btn.State = AutoHuntingBtnOnState.Instance;
    }

    /// <summary>
    /// 자신 인스턴스 입니다.
    /// </summary>
    public static AutoHuntingBtnOffState Instance { get { return instance; } }
}
