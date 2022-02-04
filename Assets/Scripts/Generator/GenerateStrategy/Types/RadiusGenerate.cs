using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ü�� ���� ��� �� ���簢���� ������ �����ϴ� �κ��Դϴ�.
/// </summary>
/// 
public class RadiusGenerate : GenerateBehaviour
{
    /// ���� ��ġ�� ��ġ ���� ����մϴ�.
    /// </summary>
    /// <param name="pos">������</param>
    /// <param name="radius">�ݰ�</param>
    /// <returns></returns>
    public Vector3 getGenerate(Vector3 pos,float radius)
    {
        //���� ���͸� �̿��Ͽ� �� ���� ������ ���� ���Ͽ� ��ġ�� �����մϴ�.
        var randNormal = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        randNormal.Normalize();
        var randR = Random.Range(0, radius);
        var resultPos = randNormal * randR;

        return pos + resultPos;
    }
}
