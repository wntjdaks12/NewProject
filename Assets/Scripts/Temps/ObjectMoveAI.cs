using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü �̵� �ΰ������Դϴ�.
/// </summary>
public class ObjectMoveAI : MonoBehaviour
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

    private Transform ts;

    private void OnEnable()
    {
        Init();
    }

    private void Awake()
    {
        curPartIndex = 0;
    }

    private void Start()
    {
        ts = GetComponent<Transform>() ?? GetComponent<Transform>();

        // ������ ��� �׸��ϴ�.
        DrawCurve();
    }

    private void Update()
    {
        if (points.Count == 0)
            // ������ ��� �ݺ��ؼ� �׸��ϴ�.
            DrawCurve();

        CheckPoint();
    }

    // �ʱ�ȭ��ŵ�ϴ�.
    private void Init()
    {
        curPartIndex = 0;

        points.Clear();
    }

    // ������ ��� �ݺ��ؼ� �׸��ϴ�.
    private void CheckPoint()
    {
        // Ʈ�������� ���� ��� �������� �ʽ��ϴ�. ---------------
        if (!ts)
            return;
        // -------------------------------------------------------

        // ���� ��ġ ���� �ش� �������� ������ ��� ���� �������� �����մϴ�. -----------
        var val1 = Points[curPartIndex]; val1.y = 0;
        var val2 = ts.position; val2.y = 0;

        if ((val1 - val2).sqrMagnitude < 0.1f)
            curPartIndex++;
        // -------------------------------------------------------------------------

        // ���� ������ ���� ��� �ʱ�ȭ��ŵ�ϴ�. -------------
        if (curPartIndex >= points.Count)
            Init();
        // ---------------------------------------------------------------
    }

    /// <summary>
    /// ������ ��� �׸��ϴ�.
    /// </summary>
    public void DrawCurve()
    {
        // Ʈ�������� ���� ��� �������� �ʽ��ϴ�. ---------------
        if (!ts)
            return;
        // -------------------------------------------------------

        // ������ ��� ������ �Է��մϴ�. ----------------------------------------------------------------------------------------------------------------------
        bezierCurve.p0 = transform.position;
        bezierCurve.p1 = new Vector3(bezierCurve.p0.x + Random.Range(min, max), transform.position.y, bezierCurve.p0.z + Random.Range(min ,max));
        bezierCurve.p2 = new Vector3(bezierCurve.p1.x + Random.Range(min, max), transform.position.y, bezierCurve.p1.z + Random.Range(min, max));
        bezierCurve.p3 = new Vector3(bezierCurve.p2.x + Random.Range(min, max), transform.position.y, bezierCurve.p2.z + Random.Range(min, max));
        // ======================================================================================================================================================
 
        // ���� �ε巯�� �̵��� ���� ������ ��� �����մϴ�.
        DivSection(0, 1f);
    }

    // ���� �ε巯�� �̵��� ���� ������ ��� �����մϴ�.
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
    public List<Vector3> Points { get { if (points.Count == 0) return null; return points; } }

    /// <summary>
    /// ���� ������ ���� �ε����Դϴ�.
    /// </summary>
    public int CurPartIndex { get { return curPartIndex; } }
}
