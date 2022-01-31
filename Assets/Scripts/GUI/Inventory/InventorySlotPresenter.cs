using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using TMPro;

public class InventorySlotPresenter : MonoBehaviour
{
    // ���� �̹����Դϴ�.
    [SerializeField]
    private Image mainImg;

    // ���� �̹����� �̸��Դϴ�. 
    [SerializeField]
    private TextMeshProUGUI nameTMP;

    // ���� ��ư�Դϴ�.
    [SerializeField]
    private Button btn;

    // �������Դϴ�.
    [SerializeField]
    private InventorySlotModel model;

    private void Start()
    {
        if (model == null) return;

        // �ش� ���� ��ġ�� �̹����� ���� ��� �����ϴ� ��Ʈ���Դϴ�.
        if (mainImg != null)
            model.ObserveEveryValueChanged(_ => model.getCharacterInfo(transform.GetSiblingIndex()).image) 
                .Subscribe(image => mainImg.sprite = Resources.Load<Sprite>("Images/Champions/" + image));

        // �ش� ���� ��ġ�� �̸��� ���� ��� �����ϴ� ��Ʈ���Դϴ�.
        if (nameTMP != null)
            model.ObserveEveryValueChanged(_ => model.getCharacterInfo(transform.GetSiblingIndex()).keyName)
                .Subscribe(text => nameTMP.text = text);

        if (btn != null)
            // ��ư Ŭ�� �� �ش� è�Ǿ��� �����մϴ�.
            btn.OnClickAsObservable()
            .Subscribe(_ => model.Create(model.getCharacterInfo(transform.GetSiblingIndex()).keyName));
    }
}
