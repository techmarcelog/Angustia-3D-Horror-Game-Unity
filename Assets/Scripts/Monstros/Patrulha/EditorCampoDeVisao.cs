using UnityEditor;
using UnityEngine;

/*[CustomEditor(typeof(CampoDeVisao))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        CampoDeVisao fov = (CampoDeVisao)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.raio);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angulo / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angulo / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.raio);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.raio);

        if (fov.podeVerPlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.referenciaPlayer.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}*/