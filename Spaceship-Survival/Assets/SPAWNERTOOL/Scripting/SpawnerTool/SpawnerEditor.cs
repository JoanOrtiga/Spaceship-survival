using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;


//[CustomEditor(typeof(LookAtPoint))]
public class SpawnerEditor : EditorWindow
{
    public RoundsData currentGraph;

    public List<int> x = new List<int>();
    
    [MenuItem ("SpawnerTool/Spawner")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(SpawnerEditor));
    }
    
    void OnGUI () {
        currentGraph = (RoundsData)EditorGUILayout.ObjectField(currentGraph, typeof(RoundsData), false, GUILayout.Width(200));

        ReorderableList reorderableList = new ReorderableList(x,typeof(int));
    }
}