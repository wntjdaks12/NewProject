using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 캐릭터를 제어하는 컨트롤러입니다.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 해당 플레이어입니다.
    /// </summary>
    public Player target;

    // 플레이어 데이터 값입니다.
    [SerializeField]
    private PlayerData playerData;

    // 조이스틱 데이터 값입니다.
    [SerializeField]
    private JoystickData jStickData;

    private void Start()
    {
        // 데이터를 읽습니다.
        DataLoad();
    }

    // 데이터를 읽습니다.
    private void DataLoad()
    {
        var data = PlayerDatabase.SearchData(target.Id);

        playerData.CharacterInfo = data;
    }

    private void FixedUpdate()
    {
        Control();
    }

    // 해당 플레이어를 제어합니다.
    private void Control()
    {
        // 널체크 -----------------------------------------------------

        // 대상에 대한 널 체크를 합니다.
        if (!target)
            return;

        // 조이스틱, 플레이어 데이터 값에 대한 널 체크를 합니다.
        if (!jStickData || !playerData)
            return;
        // ------------------------------------------------------------

        // 조이스틱 클릭 후 드래그 시 해당 플레이어는 움직입니다.
        if (jStickData.IsTouching && jStickData.PointerPosition != Vector2.zero)
            target.Move(jStickData.PointerPosition, playerData.CharacterInfo.speed);
        // 플레이어는 공격이 가능할 시 공격합니다.
        else if (target.CheckAttack())
            target.Attack(true);
        // 모든 조건이 만족하지 않을 경우 가만히 있습니다.
        else
            target.Idle();
    }
}
