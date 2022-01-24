using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// 해당 몬스터 대상입니다.
    /// </summary>
    public Monster target;

    // 해당 대상의 데이터 값입니다.
    [SerializeField]
    private MonsterData data;

    [SerializeField]
    private ObjectAI objectAI;

    // 데이터를 읽습니다.
    private void OnEnable() => DataLoad();       

    private void Start()
    {
      //  this.UpdateAsObservable()
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        if (target && data)
            data.DataLoad(target.Id);
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
        if (data == null || data.Data == null)
            return;

        if (!objectAI) return;

        // 이동할 위치과 현재 위치을 이용하여 방향을 구하고 이동을 시킵니다.
        var dir = objectAI.DirectionBehaviour.getDirection(transform.position); dir.y = 0f;
        target.Move(dir, data.Data.speed);
    }

    private void Update()
    {
        if (data == null || data.Data == null)
            return;

        if (data.Data.hp <= 0)
            target.Die();
    }

    private void FixedUpdate()
    {
        // 해당 대상을 제어합니다.
        Control();
    }

    /// <summary>
    /// 데미지를 입습니다.
    /// </summary>
    /// <param name="damage">데미지 값</param>
    public void Damage(GameObject other, int damage)
    {
        if (data != null && data.Data != null)
            data.Data.hp = HealthSystem.Damage(data.Data.hp, data.Data.maxHp, damage);

        if (objectAI)
            objectAI.DirectionBehaviour = new ObjectAITraceDirection(other);

        DamagePopup.Popup(damage, Camera.main.WorldToScreenPoint(target.transform.position));
    }

    private void asd()
    {
        
    }

    public MonsterData Data { get { return data; } }
}
