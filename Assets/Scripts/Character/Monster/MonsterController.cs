using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterController : MonoBehaviour, IHealth
{
    /// <summary>
    /// �ش� ���� ����Դϴ�.
    /// </summary>
    public Monster target;

    // �ش� ����� ������ ���Դϴ�.
    [SerializeField]
    private CharacterInfo data;

    [SerializeField]
    private ObjectMoveAI objectMoveAi;
    private void OnEnable()
    {
        // �����͸� �н��ϴ�.
        DataLoad();
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if(target)
            data = MonsterDatabase.SearchData(target.Id);
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        if (!objectMoveAi)
            return;

        //������ ���� ��� �̵��� �մϴ�. ------------------------------
        if (objectMoveAi.Points != null)
        {
            // �̵��� ������ ���� ������ �̿��Ͽ� ������ ���մϴ�.
            var p = objectMoveAi.Points[objectMoveAi.CurPartIndex];
            var dir = p - target.transform.position; dir.y = 0f;

            //�̵��մϴ�.
            target.Move(dir, data.speed);
        }
        // --------------------------------------------------------------------
    }

    private void FixedUpdate()
    {
        if (data.hp == 0)
            target.Die();
        else
            // �ش� ����� �����մϴ�.
            Control();
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(int damage)
    {
        if (data != null)
            data.hp = HealthSystem.Damage(data.hp, data.maxHp, damage);
    }
}
