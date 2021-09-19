using UnityEngine;
using UnityEditor;

public partial class EditorVisivo : UnityEditor.Editor {

    void OnSceneGUI() {
        VisualeEn fow = (VisualeEn)target;
        Handles.color = Color.white;
        var position = fow.transform.position;
        Handles.DrawWireArc (position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle (-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle (fow.viewAngle / 2, false);
        Handles.DrawLine (position, position + viewAngleA * fow.viewRadius);
        Handles.DrawLine (position, position + viewAngleB * fow.viewRadius);
        Handles.color = Color.red;
        foreach (Transform visibleTarget in VisualeEn.visibleTargets) 
        {
            if(visibleTarget!=null)
                Handles.DrawLine (fow.transform.position, visibleTarget.position);
        }
    }

}