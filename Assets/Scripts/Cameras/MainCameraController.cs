using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MainCameraController : MonoBehaviour
{
    public DragPnlData data;

    private void Start()
    {
        // ī�޶� �̵� ��Ʈ���Դϴ�.
        this.LateUpdateAsObservable()
            .Select(_ => data.dragValue / data.speed)
            .Subscribe(val => transform.position = new Vector3(val.x, transform.position.y, transform.position.z));
    }
}