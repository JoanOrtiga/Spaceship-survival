using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SpaceShipSurvival
{
    public class PlayerShooting : MonoBehaviour
    {
        public GameObject bulletPrefab;

        [SerializeField] public float timeBetweenBullets;
        private float betweenBulletsTimer;

        private void Update()
        {
            betweenBulletsTimer -= Time.deltaTime;
            
            if (Input.GetMouseButton(0) && betweenBulletsTimer <= 0)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                betweenBulletsTimer = timeBetweenBullets;
            }
        }
    }

}
