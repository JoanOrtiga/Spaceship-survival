using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Bullet : MonoBehaviour
    {
        private Shooter shooter;

        //[SerializeField] private float timeToDestroy;
        [SerializeField] private float bulletSpeed;
        public int damange = 10;

        public float timeToUnuse;

        private Rigidbody2D rb;

        private float timeToDestroy = 10f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void SetShooter(Shooter Shooter)
        {
            shooter = Shooter;
        }

        private void Update()
        {
            
            timeToDestroy -= Time.deltaTime;

            
            if (timeToDestroy <= 0)
                Destroy(gameObject);
            

            rb.velocity =transform.up * (bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("Wall"))
            {
                Invoke("UnuseBullet", timeToUnuse);
            }
            else if (other.CompareTag("Enemy"))
            {
                Invoke("UnuseBullet", timeToUnuse);
                other.GetComponent<Character>().LoseHealth(damange);
            }
        }

        private void UnuseBullet()
        {
            gameObject.SetActive(false);
            gameObject.transform.SetAsLastSibling();
            shooter.ReduceUsingBullets();
        }
    }
}
