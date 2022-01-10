using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// Ÿ�� ����Ʈ�Դϴ�.
/// </summary>
public class HitParticle : MonoBehaviour
{
    // �ش� ��ƼŬ�� ���ӽð��Դϴ�.
    [SerializeField]
    private float lifeTime;

    // ��ƼŬ �ý����� �����մϴ�.
    private ParticleSystem ps;

    // Ǯ�� �� ������Ʈ�Դϴ�.
    [SerializeField]
    private PoolableObject poolableObject;

    private void Awake() => ps = GetComponent<ParticleSystem>();

    /// <summary>
    /// Ÿ�� ����Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="other">�浹 ���</param>
    public void Active(Collider other)
    {
        if (!ps) return;
        if (poolableObject == null) return;

        // ��ƼŬ�� �����մϴ�.
        ps.Play();

        // �ش� ��� ��ġ�� �����ϴ� ��Ʈ���Դϴ�. 
        this.UpdateAsObservable()
            .Subscribe(_ => transform.position = other.transform.position);

        // �ش� ���ӽð� ���Ŀ� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        Observable
            .Timer(System.TimeSpan.FromSeconds(lifeTime))
            .Subscribe(_ => poolableObject.EnQueue());
    }
}
