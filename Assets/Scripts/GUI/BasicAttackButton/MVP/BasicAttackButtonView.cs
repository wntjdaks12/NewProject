using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttackButtonView : MonoBehaviour
{
    // �⺻ ���� �̹����Դϴ�.
    [SerializeField]
    private Image basicAttackImg;

    private BasicAttackButtonPresenter presenter;

    private void Awake()
    {
        presenter = new BasicAttackButtonPresenter(this, new BasicAttackButtonModel());
    }

    private void Start()
    {
        ChangeImage();
    }

    public void ChangeImage()
    {
        if (basicAttackImg)
            basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + presenter.basicAttackImage);
    }
}
