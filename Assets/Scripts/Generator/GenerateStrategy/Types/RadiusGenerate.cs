using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 개체의 생성 방식 중 정사각형의 내에서 생성하는 부분입니다.
/// </summary>
/// 
public class RadiusGenerate : GenerateBehaviour
{
    /// 생성 위치를 위치 값을 계산합니다.
    /// </summary>
    /// <param name="pos">기준점</param>
    /// <param name="radius">반경</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 pos,float radius)
    {
        //단위 벡터를 이용하여 원 안의 임의의 점을 구하여 위치를 리턴합니다.
        var randNormal = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        randNormal.Normalize();
        var randR = Random.Range(0, radius);
        var resultPos = randNormal * randR;

        return pos + resultPos;
    }
}
