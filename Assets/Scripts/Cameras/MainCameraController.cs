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
        this.LateUpdateAsObservable()
            .Subscribe(_ => OnDrag());
    }

    private void OnDrag()
    {
        var val = data.dragPosition / data.speed;
        transform.position = new Vector3(val.x, transform.position.y, val.y);
    }
}