using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // ���̽�ƽ ������ ���Դϴ�.
    [SerializeField]
    private JoystickData jStickData;

    private void Start()
    {
        // �����͸� �н��ϴ�.
        DataLoad();
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if (!target)
            return;

        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
    }

    private void Update()
    {
        // ���̽�ƽ Ŭ�� �� ��� ������ �������� �ʽ��ϴ�.
        if (jStickData.IsTouching)
            return;

        // �÷��̾�� ������ ������ �� �����մϴ�.
        if (target.CheckAttack())
            target.Attack(true);
        // ��� ������ �������� ���� ��� ������ �ֽ��ϴ�.
        else
            target.Idle();
    }

    private void FixedUpdate()
    {
        Control();
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        // ��üũ -----------------------------------------------------

        // ��� ���� �� üũ�� �մϴ�.
        if (!target)
            return;

        // ���̽�ƽ, �÷��̾� ������ ���� ���� �� üũ�� �մϴ�.
        if (!jStickData || !playerData)
            return;
        // ------------------------------------------------------------

        // ���̽�ƽ Ŭ�� �� �巡�� �� �ش� �÷��̾�� �����Դϴ�.
        if (jStickData.IsTouching && jStickData.PointerPosition != Vector2.zero)
            target.Move(new Vector3(jStickData.PointerPosition.x, 0, jStickData.PointerPosition.y), playerData.CharacterInfo.speed);
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(GameObject other, int damage)
    {
        if (playerData)
            playerData.CharacterInfo.hp = HealthSystem.Damage(playerData.CharacterInfo.hp, playerData.CharacterInfo.maxHp, damage);
    }
}
