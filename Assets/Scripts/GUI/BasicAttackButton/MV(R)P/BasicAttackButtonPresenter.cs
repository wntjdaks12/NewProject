using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

/// <summary>
/// �⺻ ���� ������ UGUI�� �����͸� ������ �ִ� �Ű����Դϴ�. 
/// </summary>
public class BasicAttackButtonPresenter : MonoBehaviour
{
    // �⺻ ���� �̹����Դϴ�.
    [SerializeField]
    private Image basicAttackImg;

    // �⺻ ���� �̹����� �������Դϴ�.
    private BasicAttackButtonModel model;

    private void Awake()
    {
        model = new BasicAttackButtonModel();
    }

    private void Start()
    {
        if (basicAttackImg == null) return;

        if (model == null) return;

        // �𵨿��� ������ ������ �����ϸ� �並 ������Ʈ�մϴ�.
        model.ObserveEveryValueChanged(model => model.BasicAttackImage)
            .Subscribe(imgName => basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + imgName));

        // ���� RP �����͸� �ʱ�ȭ��ŵ�ϴ�.
        model.basicAttackImageRP.Value = model.BasicAttackImage;
    }
}
