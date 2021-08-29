using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SpaceShipSurvival
{
    public class RoundController : MonoBehaviour
    {
        public RoundsData roundsData;
        public SpawneableObjects spawneableObjects;

        public SpawnPoints spawnPoints;

        private EnemyRound _round;
        private int _currentRound = 0;

        private bool _roundActive = false;
        private float _roundBreakTimer;
        public float _roundBreakTime;

        private float _roundTimer;

        public List<EnemySpawn> _enemySpawns = new List<EnemySpawn>();
        
        private void Awake()
        {
            _roundBreakTimer = _roundBreakTime;
        }

        private void Update()
        {
            if (_roundActive is false)
            {
                _roundBreakTimer -= Time.deltaTime;

                if (_roundBreakTimer <= 0)
                {
                    _roundActive = true;
                    NewRound();
                }
                
                return;
            }

            _roundTimer += Time.deltaTime;

            for (int i = 0; i < _round.spawningEnemies.Count; i++)
            {
                if (_round.spawningEnemies[i].timeToStartSpawning < _roundTimer)
                {
                    bool add = true;
                    for (int j = 0; j < _enemySpawns.Count; j++)
                    {
                        if (_enemySpawns[j].GetID() == i)
                        {
                            add = false;
                        }
                    }

                    if (add)
                    {
                        SpawningEnemy sp = _round.spawningEnemies[i];
                        _enemySpawns.Add(new EnemySpawn(i, spawnPoints.GetSpawnPointPosition(sp.spawnPointID), spawneableObjects.GetEnemyByType(sp.enemyType), sp.timeBetweenSpawn, sp.howManyEnemies));
                    }
                       
                }
            }
            
            for (int i = 0; i < _enemySpawns.Count; i++)
            {
                _enemySpawns[i].Update();
                
                if (_enemySpawns[i].IsFinished())
                {
                    Debug.Log("hola");
                    _enemySpawns.Remove(_enemySpawns[i]);
                }
            }
        }

        private void NewRound()
        {
            _roundBreakTimer = _roundBreakTime;

            _enemySpawns.Clear();
            _roundTimer = 0;
            _currentRound++;
            _round = roundsData.rounds[_currentRound];
        }
    }
}

[Serializable]
public class EnemySpawn
{
    private Vector2 _position;
    private GameObject _enemy;
    private float _timeBetweenSpawns;
    private int _quantity;

    private float _timer;

    private int _id;
    
    public EnemySpawn(int id, Vector2 position, GameObject enemy, float timeBetweenSpawns, int quantity)
    {
        _id = id;
        _position = position;
        _enemy = enemy;
        _timeBetweenSpawns = timeBetweenSpawns;
        _quantity = quantity;
        
        _timer = 0;
    }

    public void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Object.Instantiate(_enemy, _position, Quaternion.identity);
            _quantity--;
            _timer = _timeBetweenSpawns;
        }
    }

    public int GetID()
    {
        return _id;
    }
    
    public bool IsFinished()
    {
        return _quantity <= 0;
    }
}

