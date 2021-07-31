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
            Debug.Log(other);
            
            if (other.CompareTag("wall"))
            {
                UnuseBullet();
            }
            else if (other.CompareTag("Character"))
            {
                UnuseBullet();
                other.GetComponent<Character>().LoseHealth(50);
            }
        }

        private void UnuseBullet()
        {
            gameObject.SetActive(false); 
            playerShooting.numberOfUsingBullets--;
        }
    }
}
