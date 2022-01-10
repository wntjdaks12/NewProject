using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 타격 이펙트입니다.
/// </summary>
public class HitParticle : MonoBehaviour
{
    // 해당 파티클의 지속시간입니다.
    [SerializeField]
    private float lifeTime;

    // 파티클 시스템을 제어합니다.
    private ParticleSystem ps;

    // 풀링 할 오브젝트입니다.
    [SerializeField]
    private PoolableObject poolableObject;

    private void Awake() => ps = GetComponent<ParticleSystem>();

    /// <summary>
    /// 타격 이펙트를 활성화시킵니다.
    /// </summary>
    /// <param name="other">충돌 대상</param>
    public void Active(Collider other)
    {
        if (!ps) return;
        if (poolableObject == null) return;

        // 파티클을 실행합니다.
        ps.Play();

        // 해당 대상 위치로 갱신하는 스트림입니다. 
        this.UpdateAsObservable()
            .Subscribe(_ => transform.position = other.transform.position);

        // 해당 지속시간 이후에 비활성화시키는 스트림입니다.
        Observable
            .Timer(System.TimeSpan.FromSeconds(lifeTime))
            .Subscribe(_ => poolableObject.EnQueue());
    }
}
