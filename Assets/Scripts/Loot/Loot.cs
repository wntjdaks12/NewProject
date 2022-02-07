using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 전리품입니다.
/// </summary>
public class Loot : MonoBehaviour
{
    // 전리품을 던지기 위해 리지드바디를 가져옵니다.
    private Rigidbody rigid;

    // 전리품에 대한 던지는 힘입니다.
    [SerializeField]
    private float throwingPower;

    // 전리품에 대한 생존 시간입니다.
    [SerializeField]
    private float lifeTime;

    // 풀링 할 오브젝트입니다.
    [SerializeField]
    private PoolableObject poolableObject;

    private LootInfo lootInfo;

    protected DropBehaviour dropBehaviour;

    protected void Awake() => rigid = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        Throw();

        StartCoroutine(DestroyAsync());
    }

    private void Start()
    {
        this.OnCollisionEnterAsObservable()
            .Select(collision => collision.other.tag)
            .Where(tag => tag == "Player")
            .Subscribe(_ =>
            {
                Debug.Log(lootInfo);
                if (poolableObject != null) poolableObject.EnQueue();
                dropBehaviour.Drop(lootInfo.amount);
            });

    }

    /// <summary>
    /// 전리품을 던집니다.
    /// </summary>
    private void Throw()
    {
        // 전리품을 무작위 방향으로 던집니다. -------------------------------------------------------------------------------------------------------------------
        if (rigid != null)
            rigid.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0, 3f), Random.Range(-1f, 1f)) * throwingPower, ForceMode.Impulse);
        // ----------------------------------------------------------------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 전리품을 삭제시킵니다.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyAsync()
    {
        // 생존 시간이 달할 시 삭제시킵니다. -------------------------------
        yield return new WaitForSeconds(lifeTime);
        if (poolableObject != null)
            poolableObject.EnQueue();
        // ---------------------------------------------------------------
    }

    public LootInfo LootInfo { set => lootInfo = value; }
}
