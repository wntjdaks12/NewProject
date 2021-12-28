using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimePresenter
{
    private CooldownTimeView view;
    private WeaponCooldownTimeModel model;

    public CooldownTimePresenter(CooldownTimeView view, WeaponCooldownTimeModel model)
    {
        this.view = view;
        this.model = model;
    }

    public float cooldownTime { get => model.getCooldownTIme(); }
}
