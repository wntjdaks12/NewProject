using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// ��ü �̵� �ΰ������Դϴ�.
/// </summary>  
public class ObjectAI : MonoBehaviour
{
    /// <summary>
    /// ���������� ���� �� ���Դϴ�. (�̵��Ÿ��� �پ��ϰ� ǥ��) 
    /// </summary>
    public float min, max;

    // ������ ��� �����ɴϴ�. (� �̵�)
    private BezierCurve bezierCurve = new BezierCurve();

    // ������ ��� ���� �����Դϴ�. (�ε巯�� � �̵�)
    [SerializeField]
    private int parts;

    // ������ ��� ���� �����Դϴ�. (�̵��� �� �ִ� ��ġ ��)
    private List<Vector3> points = new List<Vector3>();

    // ���� ������ ���� �ε����Դϴ�. (���� ��ġ ��)
    private int curPartIndex;

    // ������ �����ִ� �������Դϴ�.
    private ObjectAIDirectionBehaviour directionBehaviour;

    private Transform ts;

    private void Awake()
    {
        curPartIndex = 0;

        directionBehaviour = new ObjectAIBezierCurveDirection(this);
    }

    private void Start()
    {
        ts = GetComponent<Transform>();

        // ������ �� ���� ������ ��� ������ ��� �ʱ�ȭ ������Ʈ ��Ʈ���Դϴ�.
        this.UpdateAsObservable()
            .Where(_ => ts && CheckPoint())
            .Subscribe(_ => Init());

        this.ObserveEveryValueChanged(_ => directionBehaviour)
            .Where(val => val == null)
            .Subscribe(_ => Init());
    }

    private void OnDisable() => directionBehaviour = null;

    /// <summary>
    /// �ʱ�ȭ��ŵ�ϴ�.
    /// </summary>
    private void Init()
    {
        curPartIndex = 0;

        points.Clear();

        // ������ �����ִ� �������Դϴ�. 
        directionBehaviour = new ObjectAIBezierCurveDirection(this);

        DrawCurve();
    }

    /// <summary>
    /// ������ ��� �� ���� üũ�մϴ�.
    /// </summary>
    private bool CheckPoint()
    {
        if (directionBehaviour == null) return false;
    
        // ���� ��ġ ���� �ش� �������� ������ ��� ���� �������� �����մϴ�. -----------------------
        var val1 = Points[curPartIndex]; val1.y = 0;
        var val2 = ts.position; val2.y = 0;

        if ((val1 - val2).sqrMagnitude < 0.1f) curPartIndex++;
        // --------------------------------------------------------------------------------------

        return curPartIndex >= points.Count ? true : false;
    }

    /// <summary>
    /// ������ ��� �׸��ϴ�.
    /// </summary>
    public void DrawCurve()
    {
        // ������ ��� ������ �Է��մϴ�. ----------------------------------------------------------------------------------------------------------------------
        bezierCurve.p0 = transform.position;
        bezierCurve.p1 = new Vector3(bezierCurve.p0.x + Random.Range(min, max), transform.position.y, bezierCurve.p0.z + Random.Range(min ,max));
        bezierCurve.p2 = new Vector3(bezierCurve.p1.x + Random.Range(min, max), transform.position.y, bezierCurve.p1.z + Random.Range(min, max));
        bezierCurve.p3 = new Vector3(bezierCurve.p2.x + Random.Range(min, max), transform.position.y, bezierCurve.p2.z + Random.Range(min, max));
        // ======================================================================================================================================================
 
        // ���� �ε巯�� �̵��� ���� ������ ��� �����մϴ�.
        DivSection(0, 1f);
    }

    /// <summary>
    /// ���� �ε巯�� �̵��� ���� ������ ��� �����մϴ�.
    /// </summary>
    /// <param name="tStart">������</param>
    /// <param name="tEnd">����</param>
    private void DivSection(float tStart, float tEnd)
    {
        // ���� ������ŭ�� �ð��� ���� ���� ���� �����ɴϴ�. -----------------
        float tDelta = (tEnd - tStart) / parts;

        for (int i = 0; i < parts; i++)
        {
            float t = tStart + tDelta * i;

            Vector3 pos = bezierCurve.getValueOfTime(t);
            points.Add(pos);
        }
        // ---------------------------------------------------------------
    }

    /// <summary>
    /// ������ ��� ���� �����Դϴ�.
    /// </summary>
    public List<Vector3> Points { get => points.Count == 0 ? null : points; }

    public List<Vector3> Pointss { get =>  points; }
    /// <summary>
    /// ���� ������ ���� �ε����Դϴ�.
    /// </summary>
    public int CurPartIndex { get => curPartIndex; }

    /// <summary>
    /// ������ �����ִ� �������Դϴ�.
    /// </summary>
    public ObjectAIDirectionBehaviour DirectionBehaviour { get => directionBehaviour; set => directionBehaviour = value; } 
}