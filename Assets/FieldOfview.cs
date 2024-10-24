using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfview : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targets;
    public LayerMask walls;


    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine ("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targets);
        print(targetsInViewRadius.Length);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                print("valid angle");
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position,dirToTarget,dstToTarget,walls))
                {
                    visibleTargets.Add(target);
                }

            }
        }
    }
    public Vector3 DirFromAngle(float angleIndegrees, bool angleIsGlobal)
    {
       if (!angleIsGlobal)
        {
            angleIndegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleIndegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleIndegrees * Mathf.Deg2Rad));
    }
}
