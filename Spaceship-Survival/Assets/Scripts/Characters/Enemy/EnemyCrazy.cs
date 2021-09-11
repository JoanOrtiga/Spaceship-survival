using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Random = System.Random;

namespace SpaceShipSurvival
{
    public class EnemyCrazy : Character
    {
        [SerializeField] private Mine _mine;
        
        private float _timer;
        [SerializeField] private Vector2 _delay = new Vector2(5, 12);

        [SerializeField] private Vector2 _distanceRange = new Vector2(5, 15);

        private Transform _target;
        private AIDestinationSetter _aiDestinationSetter;
        private AIPath _aiPath;

        private Transform _player;
        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>().transform;
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _aiPath = GetComponent<AIPath>();
            _target = new GameObject().transform;
            
            _timer = GetRandomSpawnTime();
            CalculateWanderPoint();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = GetRandomSpawnTime();
                Instantiate(_mine.gameObject, transform.position, Quaternion.identity);
            }
            
            if(_aiPath.reachedDestination)
                CalculateWanderPoint();
        }

        private void CalculateWanderPoint()
        {
            Vector2 position;
            position = UnityEngine.Random.insideUnitCircle * _distanceRange.y;
            position = (Vector2) _player.position + position;
            
            _target.position = position;
            _aiDestinationSetter.target = _target;
        }

        private float GetRandomSpawnTime()
        {
            return UnityEngine.Random.Range(_delay.x, _delay.y);
        }
        
        private void OnDrawGizmosSelected()
        {
            if(_player == null)
                _player = FindObjectOfType<PlayerController>().transform;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_player.position, _distanceRange.x);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_player.position, _distanceRange.y);
        }
    }
}
