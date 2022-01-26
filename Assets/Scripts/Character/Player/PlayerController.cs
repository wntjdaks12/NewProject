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
        // 플레이어의 행동을 컨트롤합니다.
        var updateStream = this.UpdateAsObservable();

        updateStream
            .Where(_ => target.CheckAttack())
            .Subscribe(_ => target.Attack(true));

        updateStream
            .Where(_ => !target.CheckAttack())
            .Subscribe(_ => target.Idle());

        this.FixedUpdateAsObservable()
            .Subscribe(_ => Control());
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        if (!target) return;

        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
        // 방향을 구합니다.
        if (target == null || castingData == null) return;

        var toPos = target.transform.position; toPos.y = 0;
        var fromPos = castingData.pos; fromPos.y = 0;
        var resultPos = toPos - fromPos;

        // 해당 방향과 위치로 이동합니다.
        if (castingData.target != gameObject) return;
        if (!playerData || playerData.CharacterInfo == null) return;

        if (Vector2.SqrMagnitude(resultPos) > 0.1f)
            target.Move(resultPos.normalized * -1, playerData.CharacterInfo.speed);
    }

    /// <summary>
    /// 데미지를 입습니다.
    /// </summary>
    /// <param name="damage">데미지 값</param>
    public void Damage(GameObject other, int damage)
    {
        if (playerData) playerData.CharacterInfo.hp = HealthSystem.Damage(playerData.CharacterInfo.hp, playerData.CharacterInfo.maxHp, damage);
    }
}
