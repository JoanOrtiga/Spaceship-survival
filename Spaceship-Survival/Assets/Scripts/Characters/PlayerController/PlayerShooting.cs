using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SpaceShipSurvival
{

    public class PlayerShooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletBox; //is where all the bullets will be kept

        private GameObject activeBullet;
        private GameObject instantiatedBullet;

        public int numberOfUsingBullets = 0;

        public int initialBullets;

        [SerializeField] public float timeBetweenBullets;
        private float betweenBulletsTimer;

        private void Awake()
        {
            for (int i = 0; i < initialBullets; i++)
            {
                SpawnBullet();
            }
        }
        
        private void Update()
        {
            if (betweenBulletsTimer >= 0)
            {
                betweenBulletsTimer -= Time.deltaTime;
            }
            

            else if (Input.GetMouseButton(0))
            {
                if (bulletBox.childCount == numberOfUsingBullets-1)
                {
                    SpawnBullet();
                }

                activeBullet = bulletBox.GetChild(numberOfUsingBullets).gameObject;

                activeBullet.transform.position = transform.position;
                activeBullet.transform.rotation = transform.rotation;
                activeBullet.SetActive(true);

                numberOfUsingBullets++;

                betweenBulletsTimer = timeBetweenBullets;
            }
        }

        private void SpawnBullet()
        {
            instantiatedBullet = Instantiate(bulletPrefab, bulletBox);
            instantiatedBullet.SetActive(false);
        }
    }
}
