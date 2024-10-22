using UnityEngine;
using System.Collections;

public class FieldOfview : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public Vector3 DirFromAngle(float angleIndegrees, bool angleIsGlobal)
    {
       
        return new Vector3(Mathf.Sin(angleIndegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleIndegrees * Mathf.Deg2Rad));
    }
}
