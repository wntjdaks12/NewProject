using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BasicAttackButtonPresenter : MonoBehaviour
{
    [SerializeField]
    private Image basicAttackImg;

    private BasicAttackButtonModel model;

    private void Awake()
    {
        model = new BasicAttackButtonModel();
    }

    private void Start()
    {
        if (basicAttackImg == null) return;

        if (model == null) return;

        model.basicAttackImageRP.Subscribe(imgName => basicAttackImg.sprite = Resources.Load<Sprite>("Images/BasicAttacks/" + imgName));

        model.basicAttackImageRP.Value = model.BasicAttackImage;
    }
}
