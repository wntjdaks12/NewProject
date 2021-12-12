using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ĳ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class PlayerController : MonoBehaviour
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
        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
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
            target.Move(jStickData.PointerPosition, playerData.CharacterInfo.speed);
        // �÷��̾�� ������ ������ �� �����մϴ�.
        else if (target.CheckAttack())
            target.Attack(true);
        // ��� ������ �������� ���� ��� ������ �ֽ��ϴ�.
        else
            target.Idle();
    }
}
