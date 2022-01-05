using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// 기본 공격 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class BasicAttackButtonPresenter : MonoBehaviour
{
    // 기본 공격 이미지입니다.
    [SerializeField]
    private Image basicAttackImg;

    // 기본 공격 이미지의 데이터입니다.
    private BasicAttackButtonModel model;

    private void Awake()
    {
        model = new BasicAttackButtonModel();
    }

    private void Start()
    {
        if (basicAttackImg == null) return;

        if (model == null) return;

        // 모델에서 데이터 변경을 감지하면 뷰를 업데이트합니다.
        model.ObserveEveryValueChanged(model => model.BasicAttackImage)
            .Subscribe(imgName => basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + imgName));

        // 모델의 RP 데이터를 초기화시킵니다.
        model.basicAttackImageRP.Value = model.BasicAttackImage;
    }
}
