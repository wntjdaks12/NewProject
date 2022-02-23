using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ���͸� �����ϴ� ��Ʈ�ѷ��Դϴ�.
/// </summary>
public class MonsterController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// �ش� ���� ����Դϴ�.
    /// </summary>
    public Monster target;

    // �ش� ����� ������ ���Դϴ�.
    [SerializeField]
    private MonsterData data;

  //  [SerializeField]
 //   private ObjectAI objectAI;
    [SerializeField]
    private MonsterAI monsterAI;

    private NavMeshAgent agent;

    // �����͸� �н��ϴ�.
    private void OnEnable() => DataLoad();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // �����͸� �н��ϴ�.
    private void DataLoad()
    {
        if (target && data)
            data.DataLoad(target.Id);
    }

    // �ش� �÷��̾ �����մϴ�.
    private void Control()
    {
        if (data == null || data.Data == null)
            return;

       // if (!objectAI) return;

        // �̵��� ��ġ�� ���� ��ġ�� �̿��Ͽ� ������ ���ϰ� �̵��� ��ŵ�ϴ�.
        //  var dir = objectAI.DirectionBehaviour.getDirection(transform.position); dir.y = 0f;
        // target.Move(dir, data.Data.speed);

        agent.enabled = true;
    }

    private void Update()
    {
        if (data == null || data.Data == null)
            return;

        if (data.Data.hp <= 0)
            target.Die();

        if(agent.isActiveAndEnabled && monsterAI) agent.SetDestination(monsterAI.ArrivalPoint);
    }

    private void FixedUpdate()
    {
        // �ش� ����� �����մϴ�.
        Control();
    }

    /// <summary>
    /// �������� �Խ��ϴ�.
    /// </summary>
    /// <param name="damage">������ ��</param>
    public void Damage(GameObject other, int damage)
    {
        if (data != null && data.Data != null)
            data.Data.hp = HealthSystem.Damage(data.Data.hp, data.Data.maxHp, damage);

    //    if (objectAI)
        //    objectAI.DirectionBehaviour = new ObjectAITraceDirection(other);

        DamagePopup.Popup(damage, Camera.main.WorldToScreenPoint(target.transform.position));
    }

    public MonsterData Data { get { return data; } }
}
