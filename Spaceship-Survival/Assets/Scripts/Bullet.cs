using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Bullet : MonoBehaviour
    {
        private PlayerShooting playerShooting;

        //[SerializeField] private float timeToDestroy;
        [SerializeField] private float bulletSpeed;
        public int damange = 10;

        public float timeToUnuse;

        private Rigidbody2D rb;

        private void Awake()
        {
            playerShooting = FindObjectOfType<PlayerShooting>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            /*
            timeToDestroy -= Time.deltaTime;

            
            if (timeToDestroy <= 0)
                Destroy(gameObject);
            */

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
            playerShooting.numberOfUsingBullets--;
        }
    }
}
