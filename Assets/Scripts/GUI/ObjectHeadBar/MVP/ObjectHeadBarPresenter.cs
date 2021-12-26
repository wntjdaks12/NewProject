using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI와 데이터를 연결 해주는 매개자입니다. 
/// </summary>
public class ObjectHeadBarPresenter
{
    // UI를 받기 위해 연관 관계를 가집니다.
    private ObjectHeadBarView objectHeadBarView;
    // 다양한 데이터를 받기 위해 캡슐화시키고 연관 관계를 가집니다.
    private IObjectHeadBarModel objectHeadBarModel;

    public ObjectHeadBarPresenter(ObjectHeadBarView objectHeadBarView, IObjectHeadBarModel objectHeadBarModel)
    {
        this.objectHeadBarView = objectHeadBarView;
        this.objectHeadBarModel = objectHeadBarModel;
    }

    public IObjectHeadBarModel ObjectHeadBarModel { get => objectHeadBarModel; set => objectHeadBarModel = value; }

    public int Hp {
        get {
            if (objectHeadBarModel != null)
                return objectHeadBarModel.getHp();
            return 0;
        }
    }
    public int MaxHp {
        get{
            if (objectHeadBarModel != null)
                return objectHeadBarModel.getMaaxHp();
            return 0;
        }
    }
    public int Lv {
        get{
            if (objectHeadBarModel != null)
                return objectHeadBarModel.getLv();
            return 0;
        }
    }
}
