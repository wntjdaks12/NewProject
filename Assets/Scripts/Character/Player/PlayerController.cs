using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// �÷��̾��� ĳ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class PlayerController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// �ش� �÷��̾��Դϴ�.
    /// </summary>
    public Player target;

    // �÷��̾� ������ ���Դϴ�.   
    [SerializeField]
    private PlayerData playerData;

    // ĳ���� ������ ���Դϴ�.
    [SerializeField]
    private CastingData castingData;

    private void Start()
    {
        // �÷��̾��� �ൿ�� ��Ʈ���մϴ�.
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

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if (!target) return;

        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        // ������ ���մϴ�.
        if (target == null || castingData == null) return;

        var toPos = target.transform.position; toPos.y = 0;
        var fromPos = castingData.pos; fromPos.y = 0;
        var resultPos = toPos - fromPos;

        // �ش� ����� ��ġ�� �̵��մϴ�.
        if (castingData.target != gameObject) return;
        if (!playerData || playerData.CharacterInfo == null) return;

        if (Vector2.SqrMagnitude(resultPos) > 0.1f)
            target.Move(resultPos.normalized * -1, playerData.CharacterInfo.speed);
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(GameObject other, int damage)
    {
        if (playerData) playerData.CharacterInfo.hp = HealthSystem.Damage(playerData.CharacterInfo.hp, playerData.CharacterInfo.maxHp, damage);
    }
}
