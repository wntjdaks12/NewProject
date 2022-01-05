using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx;

/// <summary>
/// 타격 이펙트를 제어자입니다.
/// </summary>
public class ParticleColllector : MonoBehaviour
{
    // 해당 파티클의 지속시간입니다.
    [SerializeField]
    private float lifeTime;

    // 관계의 최상위 개체입니다.
    private Transform parent;

    // 파티클 시스템을 제어합니다.
    private ParticleSystem ps;

    private void Start()
    {
        parent = transform.root;

        ps = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 타격 이펙트를 활성화시킵니다.
    /// </summary>
    /// <param name="other">충돌 대상</param>
    public void Active(Collider other)
    {
        if (!ps) return;
     
        // 충돌된 대상 중점에 타격 이펙트를 입힙니다. ----------------------
        transform.parent = other.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        // ----------------------------------------------------------------

        // 파티클을 실행합니다.
        ps.Play();

        // 해당 지속시간 이후에 비활성화시키는 스트림입니다.
        Observable
            .Timer(System.TimeSpan.FromSeconds(lifeTime))
            .Subscribe(_ => Disable());
    }

    /// <summary>
    /// 타격 파티클 비활성화시킵니다.
    /// </summary>
    public void Disable()
    {
        // 본래 개체의 상속관계를 유지합니다.
        transform.parent = parent;
    }
}
