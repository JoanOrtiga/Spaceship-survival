using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class EnemySniper : Character , Shooter
    {
        public float speed;

        public float distanceToPlayer;
        public float distanceToShoot;

        private Transform player;
        private AIPath aiPath;
        private AIDestinationSetter destinationSetter;
        private Transform target;
        
        [Header("Shooting")]
        public GameObject bulletPrefab;
        private Transform bulletBox; //is where all the bullets will be kept
        private GameObject activeBullet;
        private GameObject instantiatedBullet;
        private int numberOfUsingBullets = 0;
        public int initialBullets;
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
            
            
            bulletBox = new GameObject().transform;
            
            for (int i = 0; i < initialBullets; i++)
            {
                SpawnBullet();
            }
        }
        
        private void SpawnBullet()
        {
            instantiatedBullet = Instantiate(bulletPrefab, bulletBox);
            instantiatedBullet.SetActive(false);
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
            
            if (bulletBox.childCount == numberOfUsingBullets-1)
            {
                SpawnBullet();
            }

            activeBullet = bulletBox.GetChild(numberOfUsingBullets).gameObject;

            activeBullet.transform.position = transform.position;
            activeBullet.transform.rotation =
                Quaternion.LookRotation((transform.position - player.position).normalized, -Vector3.forward);
            activeBullet.GetComponent<Bullet>().SetShooter(this);
            activeBullet.SetActive(true);

            numberOfUsingBullets++;

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

        public void ReduceUsingBullets()
        {
            numberOfUsingBullets--;
        }
    }
}

