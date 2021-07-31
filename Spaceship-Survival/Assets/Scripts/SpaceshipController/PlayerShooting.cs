using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SpaceShipSurvival
{

    public class PlayerShooting : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject bulletBox; //is where all the bullets will be kept

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
                instantiatedBullet = Instantiate(bulletPrefab);

                instantiatedBullet.SetActive(false);
                instantiatedBullet.transform.parent = bulletBox.transform;
            }
        }

        private void Update()
        {
            betweenBulletsTimer -= Time.deltaTime;

            if (Input.GetMouseButton(0) && betweenBulletsTimer <= 0)
            {

                if (bulletBox.transform.childCount == numberOfUsingBullets)
                {
                    Spawn();
                }

                activeBullet = bulletBox.transform.GetChild(numberOfUsingBullets).gameObject;

                activeBullet.transform.position = transform.position;
                activeBullet.transform.rotation = transform.rotation;
                activeBullet.SetActive(true);

                numberOfUsingBullets++;

                betweenBulletsTimer = timeBetweenBullets;

                activeBullet.transform.SetAsFirstSibling();
            }
        }

        private void Spawn()
        {
            instantiatedBullet = Instantiate(bulletPrefab);

            instantiatedBullet.SetActive(false);
            instantiatedBullet.transform.parent = bulletBox.transform;
        }
    }
}
