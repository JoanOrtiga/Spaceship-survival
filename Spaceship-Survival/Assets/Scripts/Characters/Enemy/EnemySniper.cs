using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class EnemySniper : Character
    {
        public float speed;

        public float distanceToPlayer;
        public float distanceToShoot;

        private Transform _player;
        private AIPath _aiPath;
        private AIDestinationSetter _destinationSetter;
        private Transform _target;
        
        [Header("Shooting")]
        public GameObjectPooler gameObjectPoolerPrefab;
        private GameObject _activeBullet;
        [SerializeField] public float timeBetweenBullets;
        private float betweenBulletsTimer;


        protected override void Awake()
        {
            base.Awake();
            _aiPath = GetComponent<AIPath>();
            _aiPath.maxSpeed = speed;
            _player = SpaceShipLogic.GetLogic().player.transform;

            _target = new GameObject().transform;
            _target.parent = SceneReferences.Instance.InstanciatedObjectsParent;

            _destinationSetter = GetComponent<AIDestinationSetter>();
            _destinationSetter.target = _target;

            gameObjectPoolerPrefab = Instantiate(gameObjectPoolerPrefab, SceneReferences.Instance.InstanciatedObjectsParent);
        }

        private void Update()
        {
            CalculateClosePoint();
            Shoot();
        }

        private void Shoot()
        {
            if ((_player.position - transform.position).magnitude > distanceToShoot)
                return;
            
            if (betweenBulletsTimer >= 0)
            {
                betweenBulletsTimer -= Time.deltaTime;
                return;
            }

            _activeBullet = gameObjectPoolerPrefab.GetPooledObject();

            _activeBullet.GetComponent<PooledObject>().Restart();

            _activeBullet.transform.position = transform.position;
            _activeBullet.transform.rotation =
                Quaternion.LookRotation((transform.position - _player.position).normalized, -Vector3.forward);
            _activeBullet.SetActive(true);

            betweenBulletsTimer = timeBetweenBullets;
        }
        private void CalculateClosePoint()
        {
            _target.position = _player.position + (transform.position - _player.position).normalized * distanceToPlayer;
        }

        private void OnDrawGizmosSelected()
        {
            if (_player == null)
            {
                _player = FindObjectOfType<PlayerController>().transform;
            }
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_player.position, distanceToShoot);
            Gizmos.color = Color.white;
            Gizmos.DrawRay(_player.position, (transform.position - _player.position).normalized * distanceToPlayer);
        }
    }
}

