using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체 이동 인공지능입니다.
/// </summary>
public class ObjectMoveAI : MonoBehaviour
{
    /// <summary>
    /// 정점마다의 랜덤 한 값입니다. (이동거리를 다양하게 표현) 
    /// </summary>
    public float min, max;

    // 베지어 곡선을 가져옵니다. (곡선 이동)
    private BezierCurve bezierCurve = new BezierCurve();

    // 베지어 곡선을 나눌 개수입니다. (부드러운 곡선 이동)
    [SerializeField]
    private int parts;

    // 베지어 곡선을 나눈 정점입니다. (이동할 수 있는 위치 값)
    private List<Vector3> points = new List<Vector3>();

    // 나눈 정점의 현재 인덱스입니다. (현재 위치 값)
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

        // 베지어 곡선을 그립니다.
        DrawCurve();
    }

    private void Update()
    {
        if (points.Count == 0)
            // 베지어 곡선을 반복해서 그립니다.
            DrawCurve();

        CheckPoint();
    }

    // 초기화시킵니다.
    private void Init()
    {
        curPartIndex = 0;

        points.Clear();
    }

    // 베지어 곡선을 반복해서 그립니다.
    private void CheckPoint()
    {
        // 트렌스폼이 없을 경우 실행하지 않습니다. ---------------
        if (!ts)
            return;
        // -------------------------------------------------------

        // 현재 위치 값이 해당 정점까지 근접할 경우 다음 정점으로 변경합니다. -----------
        var val1 = Points[curPartIndex]; val1.y = 0;
        var val2 = ts.position; val2.y = 0;

        if ((val1 - val2).sqrMagnitude < 0.1f)
            curPartIndex++;
        // -------------------------------------------------------------------------

        // 다음 정점이 없을 경우 초기화시킵니다. -------------
        if (curPartIndex >= points.Count)
            Init();
        // ---------------------------------------------------------------
    }

    /// <summary>
    /// 베지어 곡선을 그립니다.
    /// </summary>
    public void DrawCurve()
    {
        // 트렌스폼이 없을 경우 실행하지 않습니다. ---------------
        if (!ts)
            return;
        // -------------------------------------------------------

        // 베지어 곡선의 정점을 입력합니다. ----------------------------------------------------------------------------------------------------------------------
        bezierCurve.p0 = transform.position;
        bezierCurve.p1 = new Vector3(bezierCurve.p0.x + Random.Range(min, max), transform.position.y, bezierCurve.p0.z + Random.Range(min ,max));
        bezierCurve.p2 = new Vector3(bezierCurve.p1.x + Random.Range(min, max), transform.position.y, bezierCurve.p1.z + Random.Range(min, max));
        bezierCurve.p3 = new Vector3(bezierCurve.p2.x + Random.Range(min, max), transform.position.y, bezierCurve.p2.z + Random.Range(min, max));
        // ======================================================================================================================================================
 
        // 보다 부드러운 이동을 위해 베지어 곡선을 분할합니다.
        DivSection(0, 1f);
    }

    // 보다 부드러운 이동을 위해 베지어 곡선을 분할합니다.
    private void DivSection(float tStart, float tEnd)
    {
        // 나눈 개수만큼의 시간에 대한 정점 값을 가져옵니다. -----------------
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
    /// 베지어 곡선을 나눈 정점입니다.
    /// </summary>
    public List<Vector3> Points { get { if (points.Count == 0) return null; return points; } }

    /// <summary>
    /// 나눈 정점의 현재 인덱스입니다.
    /// </summary>
    public int CurPartIndex { get { return curPartIndex; } }
}
