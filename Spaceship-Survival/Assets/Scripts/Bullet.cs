using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy;
        [SerializeField] private float bulletSpeed;


        private Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
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
            //Lesshp
            Destroy(gameObject, 0.05f);
        }
    }
}
