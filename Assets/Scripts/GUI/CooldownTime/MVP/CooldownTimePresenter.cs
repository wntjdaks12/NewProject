using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimePresenter
{
    private ICooldownTimeView view;
    private ICooldownTimeModel model;

    public CooldownTimePresenter(ICooldownTimeView view, ICooldownTimeModel model)
    {
        this.view = view;
        this.model = model;
    }

    public float CurCooldownTime { get => model.getCurCooldownTIme(); }
    public float CooldownTime { get => model.getCooldownTIme(); }
}
