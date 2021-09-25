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

        private Transform player;
        private AIPath aiPath;
        private AIDestinationSetter destinationSetter;
        private Transform target;
        
        [Header("Shooting")]
        public GameObjectPooler gameObjectPoolerPrefab;
        private GameObject activeBullet;
        [SerializeField] public float timeBetweenBullets;
        private float betweenBulletsTimer;


        protected override void Awake()
        {
            base.Awake();
            aiPath = GetComponent<AIPath>();
            aiPath.maxSpeed = speed;
            player = SpaceShipLogic.GetLogic().player.transform;

            target = new GameObject().transform;

            destinationSetter = GetComponent<AIDestinationSetter>();
            destinationSetter.target = target;

            gameObjectPoolerPrefab = Instantiate(gameObjectPoolerPrefab);
        }

        private void Update()
        {
            CalculateClosePoint();
            Shoot();
        }

        private void Shoot()
        {
            /*if ((player.position - transform.position).sqrMagnitude > distanceToShoot)
                return;*/
            
            if (betweenBulletsTimer >= 0)
            {
                betweenBulletsTimer -= Time.deltaTime;
                return;
            }

            activeBullet = gameObjectPoolerPrefab.GetPooledObject();

            activeBullet.GetComponent<PooledObject>().Restart();

            activeBullet.transform.position = transform.position;
            activeBullet.transform.rotation =
                Quaternion.LookRotation((transform.position - player.position).normalized, -Vector3.forward);
            activeBullet.SetActive(true);

            betweenBulletsTimer = timeBetweenBullets;
        }
        private void CalculateClosePoint()
        {
            target.position = player.position + (transform.position - player.position).normalized * distanceToPlayer;
        }

        private void OnDrawGizmosSelected()
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerController>().transform;
            }
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(player.position, distanceToShoot);
            Gizmos.color = Color.white;
            Gizmos.DrawRay(player.position, (transform.position - player.position).normalized * distanceToPlayer);
        }
    }
}

