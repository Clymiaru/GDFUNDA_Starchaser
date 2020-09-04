using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Launcher))]
public class LaunchPadDestinationHandle : Editor
{
    private Transform launcher;

    private void OnEnable()
    {
        launcher = (target as Launcher).transform;
    }

    private void OnSceneGUI()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireCube(launcher.position, new Vector3(1.0f, 1.0f, 1.0f));
    }

}
