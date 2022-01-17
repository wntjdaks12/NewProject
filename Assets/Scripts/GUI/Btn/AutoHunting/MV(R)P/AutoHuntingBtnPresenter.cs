using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 자동 사냥 버튼과 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class AutoHuntingBtnPresenter : MonoBehaviour
{
    // 자동 사냥 데이터입니다.
    private AutoHuntingModel model;

    // 버튼의 현재 상태입니다.
    private AutoHuntingBtnState state;

    // 버튼 이미지입니다.
    [SerializeField]
    private Image img;

    private void Awake()
    {
        model = new AutoHuntingModel();

        state = new AutoHuntingBtnOffState();
    }

    private void Start()
    {
        if (img == null) return;

        // 자동 사냥일 경우 버튼을 활성화하는 스트림입니다.
        model.AutoHuntingData.ObserveEveryValueChanged(data => data.isAuto)
            .Where(isAuto => isAuto)
            .Subscribe(_ => state?.On(this));

        // 자동 사냥이 아닐 경우 버튼을 비활성화하느 스트림입니다.
        model.AutoHuntingData.ObserveEveryValueChanged(data => data.isAuto)
            .Where(isAuto => !isAuto)
            .Subscribe(_ => state?.Off(this));
    }

    /// <summary>
    /// 버튼을 클릭합니다.
    /// </summary>
    public void OnClick()
    {
        if (model != null && model.AutoHuntingData != null)
            model.AutoHuntingData.isAuto = !model.AutoHuntingData.isAuto;
    }

    /// <summary>
    /// 버튼 이미지입니다.
    /// </summary>
    public Image Img { get => img; }

    /// <summary>
    /// 버튼의 현재 상태입니다.
    /// </summary>
    public AutoHuntingBtnState State { set => state = value; }
}

