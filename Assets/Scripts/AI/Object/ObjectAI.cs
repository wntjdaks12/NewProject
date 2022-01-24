using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// 개체 이동 인공지능입니다.
/// </summary>  
public class ObjectAI : MonoBehaviour
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

    // 방향을 정해주는 행위자입니다.
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

        // 베지어 끝 점에 도달할 경우 베지어 곡선을 초기화 업데이트 스트림입니다.
        this.UpdateAsObservable()
            .Where(_ => ts && CheckPoint())
            .Subscribe(_ => Init());

        this.ObserveEveryValueChanged(_ => directionBehaviour)
            .Where(val => val == null)
            .Subscribe(_ => Init());
    }

    private void OnDisable() => directionBehaviour = null;

    /// <summary>
    /// 초기화시킵니다.
    /// </summary>
    private void Init()
    {
        curPartIndex = 0;

        points.Clear();

        // 방향을 정해주는 행위자입니다. 
        directionBehaviour = new ObjectAIBezierCurveDirection(this);

        DrawCurve();
    }

    /// <summary>
    /// 베지어 곡선의 끝 점을 체크합니다.
    /// </summary>
    private bool CheckPoint()
    {
        if (directionBehaviour == null) return false;
    
        // 현재 위치 값이 해당 정점까지 근접할 경우 다음 정점으로 변경합니다. -----------------------
        var val1 = Points[curPartIndex]; val1.y = 0;
        var val2 = ts.position; val2.y = 0;

        if ((val1 - val2).sqrMagnitude < 0.1f) curPartIndex++;
        // --------------------------------------------------------------------------------------

        return curPartIndex >= points.Count ? true : false;
    }

    /// <summary>
    /// 베지어 곡선을 그립니다.
    /// </summary>
    public void DrawCurve()
    {
        // 베지어 곡선의 정점을 입력합니다. ----------------------------------------------------------------------------------------------------------------------
        bezierCurve.p0 = transform.position;
        bezierCurve.p1 = new Vector3(bezierCurve.p0.x + Random.Range(min, max), transform.position.y, bezierCurve.p0.z + Random.Range(min ,max));
        bezierCurve.p2 = new Vector3(bezierCurve.p1.x + Random.Range(min, max), transform.position.y, bezierCurve.p1.z + Random.Range(min, max));
        bezierCurve.p3 = new Vector3(bezierCurve.p2.x + Random.Range(min, max), transform.position.y, bezierCurve.p2.z + Random.Range(min, max));
        // ======================================================================================================================================================
 
        // 보다 부드러운 이동을 위해 베지어 곡선을 분할합니다.
        DivSection(0, 1f);
    }

    /// <summary>
    /// 보다 부드러운 이동을 위해 베지어 곡선을 분할합니다.
    /// </summary>
    /// <param name="tStart">시작점</param>
    /// <param name="tEnd">끝점</param>
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
    public List<Vector3> Points { get => points.Count == 0 ? null : points; }

    public List<Vector3> Pointss { get =>  points; }
    /// <summary>
    /// 나눈 정점의 현재 인덱스입니다.
    /// </summary>
    public int CurPartIndex { get => curPartIndex; }

    /// <summary>
    /// 방향을 정해주는 행위자입니다.
    /// </summary>
    public ObjectAIDirectionBehaviour DirectionBehaviour { get => directionBehaviour; set => directionBehaviour = value; } 
}