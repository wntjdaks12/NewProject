using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI�� �����͸� ���� ���ִ� �Ű����Դϴ�. 
/// </summary>
public class ObjectHeadBarPresenter
{
    // UI�� �ޱ� ���� ���� ���踦 �����ϴ�.
    private ObjectHeadBarView objectHeadBarView;
    // �پ��� �����͸� �ޱ� ���� ĸ��ȭ��Ű�� ���� ���踦 �����ϴ�.
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
