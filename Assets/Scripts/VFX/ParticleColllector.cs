using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx;

/// <summary>
/// Ÿ�� ����Ʈ�� �������Դϴ�.
/// </summary>
public class ParticleColllector : MonoBehaviour
{
    // �ش� ��ƼŬ�� ���ӽð��Դϴ�.
    [SerializeField]
    private float lifeTime;

    // ������ �ֻ��� ��ü�Դϴ�.
    private Transform parent;

    // ��ƼŬ �ý����� �����մϴ�.
    private ParticleSystem ps;

    private void Start()
    {
        parent = transform.root;

        ps = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Ÿ�� ����Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    /// <param name="other">�浹 ���</param>
    public void Active(Collider other)
    {
        if (!ps) return;
     
        // �浹�� ��� ������ Ÿ�� ����Ʈ�� �����ϴ�. ----------------------
        transform.parent = other.transform;
        transform.localPosition = new Vector3(0, 0, 0);
        // ----------------------------------------------------------------

        // ��ƼŬ�� �����մϴ�.
        ps.Play();

        // �ش� ���ӽð� ���Ŀ� ��Ȱ��ȭ��Ű�� ��Ʈ���Դϴ�.
        Observable
            .Timer(System.TimeSpan.FromSeconds(lifeTime))
            .Subscribe(_ => Disable());
    }

    /// <summary>
    /// Ÿ�� ��ƼŬ ��Ȱ��ȭ��ŵ�ϴ�.
    /// </summary>
    public void Disable()
    {
        // ���� ��ü�� ��Ӱ��踦 �����մϴ�.
        transform.parent = parent;
    }
}
