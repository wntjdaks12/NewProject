using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 플레이어의 캐릭터를 제어하는 컨트롤러입니다.
/// </summary>
public class PlayerController : MonoBehaviour, IDamageable, ICastingPosition
{
    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Champion target;

    // 플레이어 데이터 값입니다.   
    [SerializeField]
    private PlayerData playerData;

    // 캐스팅 데이터 값입니다.
    [SerializeField]
    private CastingData castingData;

    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;

        if (target == null) return;

        // 플레이어의 행동을 컨트롤합니다.
        var updateStream = this.UpdateAsObservable()
            .Select(_ => target.transform.position - pos)
            .Select(pos => new Vector3(pos.x, 0, pos.z));

        updateStream
            .Where(pos => Vector3.SqrMagnitude(pos) <= 0.1f)
            .Where(_ => target.CheckAttack())
            .Subscribe(_ => target.Attack(true));

        updateStream
            .Where(pos => Vector3.SqrMagnitude(pos) <= 0.1f)
            .Subscribe(_ => target.Idle());

        updateStream
            .Where(pos => Vector3.SqrMagnitude(pos) > 0.1f)
            .Subscribe(rot => { Debug.Log(transform.root); Move(rot * -1); });
            
        DataLoad();
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
        if (playerData != null && playerData.CharacterInfo != null)
            target.Move(rotation, playerData.CharacterInfo.speed);
    }

    public void setPos(Vector3 pos) => this.pos = pos;
}
