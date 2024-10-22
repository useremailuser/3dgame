using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (FieldOfview))]
public class FOVeditor : Editor
{
    void OnsceneGUI()
    {
        FieldOfview fow = (FieldOfview)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
    }
    
}
