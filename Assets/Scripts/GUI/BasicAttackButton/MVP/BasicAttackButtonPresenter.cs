using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackButtonPresenter
{
    private BasicAttackButtonView view;
    private BasicAttackButtonModel model;

    public BasicAttackButtonPresenter(BasicAttackButtonView view, BasicAttackButtonModel model)
    {
        this.view = view;
        this.model = model;
    }

    public string basicAttackImage { get => model.BasicAttackImage; }
}
