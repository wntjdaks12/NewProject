using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 몬스터를 제어하는 컨트롤러입니다.
/// </summary>
public class MonsterController : MonoBehaviour, IHealth
{
    /// <summary>
    /// 해당 몬스터 대상입니다.
    /// </summary>
    public Monster target;

    // 해당 대상의 데이터 값입니다.
    [SerializeField]
    private CharacterInfo data;

    [SerializeField]
    private ObjectMoveAI objectMoveAi;
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
        if (!objectMoveAi)
            return;

        //정점이 있을 경우 이동을 합니다. ------------------------------
        if (objectMoveAi.Points != null)
        {
            // 이동할 정점과 현재 정점을 이용하여 방향을 구합니다.
            var p = objectMoveAi.Points[objectMoveAi.CurPartIndex];
            var dir = p - target.transform.position; dir.y = 0f;

            //이동합니다.
            target.Move(dir, data.speed);
        }
        // --------------------------------------------------------------------
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
    public void Damage(int damage)
    {
        if (data != null)
            data.hp = HealthSystem.Damage(data.hp, data.maxHp, damage);
    }
}
