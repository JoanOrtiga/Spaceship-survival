using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class EnemyKamikaze : Enemy
    {
        public int damage;
        
        [Header("Movement")]
        public float normalSpeed;
        public float attackSpeed;
        public float distanceToAccelerate;
        
        private Transform player;
        private AIPath aiPath;
        
        protected override void Awake()
        {
            enemyType = EnemyType.KAMIKAZE;
            base.Awake();
            player = SpaceShipLogic.GetLogic().player.transform;
            GetComponent<AIDestinationSetter>().target = player;

            aiPath = GetComponent<AIPath>();
            aiPath.maxSpeed = normalSpeed;
        }

        private void Update()
        {
            if ((player.position - transform.position).sqrMagnitude < distanceToAccelerate)
            {
                aiPath.maxSpeed = attackSpeed;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
                other.GetComponent<Character>().LoseHealth(damage);
                //Explosion particles
                Destroy(gameObject, 0.05f);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (player == null)
            {
                player = FindObjectOfType<PlayerController>().transform;
            }
            
            Gizmos.DrawRay(player.position, (transform.position - player.position).normalized * Mathf.Sqrt(distanceToAccelerate));
        }
    }
}

