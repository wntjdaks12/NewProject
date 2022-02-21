using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class AlertBtn : MonoBehaviour
{  
    public GameObject target;

    [SerializeField]
    private RectTransform rectTs;

    private void Start() =>
        this.UpdateAsObservable()
            .Subscribe(_ => rectTs.position = Camera.main.WorldToScreenPoint(target.transform.position));
}
