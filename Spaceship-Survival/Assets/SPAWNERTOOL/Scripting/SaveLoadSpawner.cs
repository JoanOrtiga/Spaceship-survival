using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadSpawner : MonoBehaviour
{
    public RoundsData roundsData;
    private TrackEditor _trackEditor;
    
    private void OnEnable()
    {
        _trackEditor = FindObjectOfType<TrackEditor>();
    }

    public void Save(int round)
    {
        _trackEditor.SaveRound(roundsData, round);
    }

    public void Load(int round)
    {
        _trackEditor.LoadRound(roundsData, round);
    }

    public void SaveActualRound()
    {
        _trackEditor.SaveRound(roundsData, int.Parse(_trackEditor.round.text)); 
    }
    
    public void LoadActualRound()
    {
       _trackEditor.ClearBlocks();
        _trackEditor.LoadRound(roundsData, int.Parse(_trackEditor.round.text)); 
    }
}

[InitializeOnLoad]
public static class PlayStateNotifier
{
    static PlayStateNotifier()
    {
        EditorApplication.playModeStateChanged += ModeChanged;
    }
      
    static void ModeChanged(PlayModeStateChange playModeState)
    {
        if (SceneManager.GetActiveScene().name == "SpawnerTool")
        {
            if (playModeState == PlayModeStateChange.ExitingPlayMode) 
            {
                GameObject.FindObjectOfType<SaveLoadSpawner>().Save(int.Parse(GameObject.FindObjectOfType<TrackEditor>().round.text));
                Debug.Log("Exit");
            }
            else if (playModeState == PlayModeStateChange.EnteredPlayMode)
            {
                GameObject.FindObjectOfType<SaveLoadSpawner>().Load(1);
            }
        }
    }
}
