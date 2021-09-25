using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SpaceShipSurvival
{

    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private GameObjectPooler gameObjectPoolerPrefab;
        
        private GameObject activeBullet;
        
        [SerializeField] public float timeBetweenBullets;
        private float betweenBulletsTimer;

        private void Awake()
        {
            gameObjectPoolerPrefab = Instantiate(gameObjectPoolerPrefab);
        }

        private void Update()
        {
            if (betweenBulletsTimer >= 0)
            {
                betweenBulletsTimer -= Time.deltaTime;
            }
            else if (Input.GetMouseButton(0))
            {
                activeBullet = gameObjectPoolerPrefab.GetPooledObject();
                
                activeBullet.GetComponent<PooledObject>().Restart();
                activeBullet.transform.position = transform.position;
                activeBullet.transform.rotation = transform.rotation;
                activeBullet.SetActive(true);

                betweenBulletsTimer = timeBetweenBullets;
            }
        }
    }
}
