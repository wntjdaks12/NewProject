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
    private CharacterInfo data;

    [SerializeField]
    private ObjectAI objectAI;
    private void OnEnable()
    {
        // 데이터를 읽습니다.
        DataLoad();
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        if(target)
            data = MonsterDatabase.SearchData(target.Id);
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
        if (!objectAI)
            return;

        // 이동할 위치과 현재 위치을 이용하여 방향을 구하고 이동을 시킵니다.
        var dir = objectAI.DirectionBehaviour.getDirection(transform.position); dir.y = 0f;
        target.Move(dir, data.speed);

    }

    private void FixedUpdate()
    {
        if (data.hp == 0)
            target.Die();
        else
            // 해당 대상을 제어합니다.
            Control();
    }

    /// <summary>
    /// 데미지를 입습니다.
    /// </summary>
    /// <param name="damage">데미지 값</param>
    public void Damage(GameObject other, int damage)
    {
        if (data != null)
            data.hp = HealthSystem.Damage(data.hp, data.maxHp, damage);

        if (objectAI)
            objectAI.DirectionBehaviour = new ObjectAITraceDirection(other);
    }
}
