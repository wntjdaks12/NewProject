using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 플레이어의 캐릭터를 제어하는 컨트롤러입니다.
/// </summary>
public class PlayerController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    // 플레이어 데이터 값입니다.   
    [SerializeField]
    private PlayerData playerData;

    // 캐스팅 데이터 값입니다.
    [SerializeField]
    private CastingData castingData;

    private void Start()
    {
        if (target == null || castingData == null) return;

        // 플레이어의 행동을 컨트롤합니다.
        var updateStream = this.UpdateAsObservable();

        updateStream
            .Where(_ => target.CheckAttack())
            .Subscribe(_ => target.Attack(true));

        updateStream
            .Select(_ => target.transform.position - castingData.pos)
            .Select(pos => new Vector3(pos.x, 0, pos.z))
            .Where(pos => Vector3.SqrMagnitude(pos) <= 0.1f)
            .Subscribe(_ => target.Idle());

        this.FixedUpdateAsObservable()
            .Select(_ => target.transform.position - castingData.pos)
            .Select(pos => new Vector3(pos.x, 0, pos.z))
            .Where(pos => Vector3.SqrMagnitude(pos) > 0.1f)
            .Subscribe(rot => Move(rot * -1));
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        if (!target) return;

        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
    }

    /// <summary>
    /// 데미지를 입습니다.
    /// </summary>
    /// <param name="damage">데미지 값</param>
    public void Damage(GameObject other, int damage)
    {
        if (playerData) playerData.CharacterInfo.hp = HealthSystem.Damage(playerData.CharacterInfo.hp, playerData.CharacterInfo.maxHp, damage);
    }

    // 이동시킵니다.
    private void Move(Vector3 rotation)
    {
        if (castingData.target == gameObject)
            target.Move(rotation, playerData.CharacterInfo.speed);
    }
}
