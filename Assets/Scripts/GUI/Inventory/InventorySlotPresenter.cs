using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class InventorySlotPresenter : MonoBehaviour
{

    // ���� �̹����Դϴ�.
    [SerializeField]
    private Image mainImg;

    // ���� �̹����� �̸��Դϴ�. 
    [SerializeField]
    private TextMeshProUGUI nameTMP;

    // �������Դϴ�.
    private IntentorySlotModel model;

    private void Awake() => model = new IntentorySlotModel();

    private void Start()
    {
        if (model == null) return;

        // �ش� ���� ��ġ�� �̹����� ���� ��� �����ϴ� ��Ʈ���Դϴ�.
        if (mainImg != null)
            model.ObserveEveryValueChanged(_ => model.getWeaponInfo(transform.GetSiblingIndex()).image) 
                .Subscribe(image => mainImg.sprite = Resources.Load<Sprite>("Images/Weapons/" + image));

        // �ش� ���� ��ġ�� �̸��� ���� ��� �����ϴ� ��Ʈ���Դϴ�.
        if (nameTMP != null)
            model.ObserveEveryValueChanged(_ => model.getWeaponInfo(transform.GetSiblingIndex()).keyName)
                .Subscribe(text => nameTMP.text = text);
    }

    /// <summary>
    /// ���� ���� �����͸� �ٲߴϴ�.
    /// </summary>
    public void Click()
    {
        if (model != null) model.WeaponInfo = model.getWeaponInfo(transform.GetSiblingIndex());
    }
}
