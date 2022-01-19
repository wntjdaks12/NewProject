using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

/// <summary>
/// �������� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class StageSlotPresenter : MonoBehaviour
{
    // �������� �̹����Դϴ�.
    [SerializeField]
    private Image img;

    // �������� ������ �������Դϴ�.
    private StageSlotModel model;

    // �������� ������ �ε��� ���Դϴ�.
    private int index;

    [SerializeField]
    private Button btn;

    private void Awake() => model = new StageSlotModel();

    private void Start()
    {
        // ���� �ε����� �����ɴϴ�.
        index = transform.GetSiblingIndex();

        // �������� ������ �̹����� �����ִ� ��Ʈ���Դϴ�.
        if (model.Data != null)
            model.ObserveEveryValueChanged(model => model.Data.stageInfo.stage2Info[index].image)
                .Subscribe(_ => img.sprite = Resources.Load<Sprite>("Images/Stages/" + model.Data.stageInfo.stage2Info[index].image));

        // ��ư Ŭ�� �� �� �̵��ϴ� ��Ʈ���Դϴ�.
        if(btn != null)
           btn.OnClickAsObservable().Subscribe(_ => SceneManager.LoadScene(model.Data.stageInfo.stage2Info[index].id));
    }
}
