using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// 스테이지 슬롯의 UGUI와 데이터를 연결해 주는 매개자입니다. 
/// </summary>
public class StageSlotPresenter : MonoBehaviour
{
    // 스테이지 이미지입니다.
    [SerializeField]
    private Image img;

    // 스테이지 슬롯의 데이터입니다.
    private StageSlotModel model;

    // 스테이지 슬롯의 인덱스 값입니다.
    private int index;

    [SerializeField]
    private Button btn;

    private void Awake() => model = new StageSlotModel();

    private void Start()
    {
        // 현재 인덱스를 가져옵니다.
        index = transform.GetSiblingIndex();

        // 스테이지 슬롯의 이미지를 보여주는 스트림입니다.
        if (model.Data != null)
            model.ObserveEveryValueChanged(model => model.Data.stageInfo.stage2Info[index].image)
                .Subscribe(_ => img.sprite = Resources.Load<Sprite>("Images/Stages/" + model.Data.stageInfo.stage2Info[index].image));

        // 버튼 클릭 시 씬 이동하는 스트림입니다.
        if(btn != null)
           btn.OnClickAsObservable().Subscribe(_ => SceneManager.LoadScene(model.Data.stageInfo.stage2Info[index].id));
    }
}
