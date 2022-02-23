using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Random = UnityEngine.Random;

public class MonsterAI : MonoBehaviour
{
    private Vector3 arrivalPoint;
    private Vector3 tempPos;

    [SerializeField]
    private Transform targetTs;

    private void Awake() =>
        arrivalPoint = targetTs.position;

    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Vector3.SqrMagnitude(arrivalPoint - targetTs.position) <= 0.1f)
            .Subscribe(_ => ResetPoint());

        StartCoroutine(CheckPositionAsync());
    }

    private void ResetPoint() =>
        arrivalPoint = targetTs.position + new Vector3(Random.Range(-10f, 10f), targetTs.position.y, Random.Range(-10f, 10f));

    private IEnumerator CheckPositionAsync()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Vector3.SqrMagnitude(targetTs.position - tempPos) <= 0.1f) ResetPoint();

            tempPos = targetTs.position;
        }
    }

    public Vector3 ArrivalPoint { get => arrivalPoint; }
}
