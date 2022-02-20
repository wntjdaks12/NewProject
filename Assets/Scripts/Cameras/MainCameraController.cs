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
        // 카메라 이동 스트림입니다.
        this.LateUpdateAsObservable()
            .Select(_ => data.dragValue / data.speed)
            .Subscribe(val => transform.position = new Vector3(val.x, transform.position.y, transform.position.z));
    }
}