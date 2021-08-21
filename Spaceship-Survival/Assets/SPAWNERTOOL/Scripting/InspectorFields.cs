using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorFields : MonoBehaviour
{
    public static InspectorFields Instance;

    public InputField spawnPointID;
    public InputField timeToStartSpawning;
    public InputField howManyEnemies;
    public Dropdown enemyTypeDropdown;
    public InputField timeBetweenSpawn;

    private TrackEditor _trackEditor;

    private void Awake()
    {
        Instance = this;

        _trackEditor = FindObjectOfType<TrackEditor>();
        enemyTypeDropdown.options.Clear();

        for (int i = 0; i < Enum.GetNames(typeof(EnemyType)).Length; i++)
        {
            enemyTypeDropdown.options.Add(new Dropdown.OptionData(((EnemyType)i).ToString()));
        }
        
    }

    private void Update()
    {
        if (_trackEditor.selected == null)
        {
            spawnPointID.text = String.Empty;
            timeToStartSpawning.text = String.Empty;
            howManyEnemies.text = String.Empty;
            timeBetweenSpawn.text = String.Empty;
        }
    }

    public void OnSpawnPointID(string change)
    {
        if (_trackEditor.selected == null)
            return;

        var selectedSpawningEnemy = _trackEditor.selected._spawningEnemy;

        int temp;
        if (int.TryParse(change, out temp))
            selectedSpawningEnemy.spawnPointID = temp;
    }

    public void OnTimeToStartSpawning(string change)
    {
        if (_trackEditor.selected == null)
            return;

        change = change.Replace('.', ',');
        
        float temp;
        if (float.TryParse(change, out temp))
        {
            _trackEditor.selected._spawningEnemy.timeToStartSpawning = temp;

            float localXPosition = temp * _trackEditor.CellXSize;

            _trackEditor.selected.GetComponent<RectTransform>().localPosition = new Vector2(localXPosition,
                _trackEditor.selected.GetComponent<RectTransform>().localPosition.y);
        }
            
    }

    public void OnHowManyEnemies(string change)
    {
        if (_trackEditor.selected == null)
            return;

        int temp;
        if (int.TryParse(change, out temp))
        {
            _trackEditor.selected._spawningEnemy.howManyEnemies = temp;

            float x = Mathf.Max(1 * _trackEditor.CellXSize,
                (float) _trackEditor.selected._spawningEnemy.howManyEnemies *
                _trackEditor.selected._spawningEnemy.timeBetweenSpawn * _trackEditor.CellXSize);

            _trackEditor.selected.myRect.sizeDelta = new Vector2(x, _trackEditor.selected.myRect.sizeDelta.y);
        }
    }

    public void OnTimeBetweenSpawn(string change)
    {
        if (_trackEditor.selected == null)
            return;
        
        change = change.Replace('.', ',');
        
        float temp;
        if (float.TryParse(change, out temp))
        {
            _trackEditor.selected._spawningEnemy.timeBetweenSpawn = temp;

            float x = Mathf.Max(1 * _trackEditor.CellXSize,
                (float) _trackEditor.selected._spawningEnemy.howManyEnemies *
                _trackEditor.selected._spawningEnemy.timeBetweenSpawn * _trackEditor.CellXSize);

            _trackEditor.selected.myRect.sizeDelta = new Vector2(x, _trackEditor.selected.myRect.sizeDelta.y);
        }
    }

    public void OnEnemyType(int option)
    {
        if (_trackEditor.selected == null)
            return;
        
        EnemyType enemy = (EnemyType) option;
        _trackEditor.selected._spawningEnemy.enemyType = enemy;
        _trackEditor.selected.ChangeEnemyType(enemy);
    }
}