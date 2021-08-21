using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public List<Transform> spawns = new List<Transform>();

#if UNITY_EDITOR
    [Header("Debug")] 
    public bool showPoints = true;
    public int fontSize = 20;
    public Color fontColor = Color.white;
    
    private void OnDrawGizmos()
    {
        if(!showPoints)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            DrawTextOnEditor.DrawString(i.ToString(), transform.GetChild(i).position, fontColor, fontSize);
        }
    }
#endif

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawns.Add(transform.GetChild(i));
        }
    }

    public Vector2 GetSpawnPointPosition(int id)
    {
        return spawns[id].position;
    }
}
