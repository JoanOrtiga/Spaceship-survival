using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Mine : MonoBehaviour
    {
        public GameObject explosion;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                //explosion.SetActive(true);
                //gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 2f);
                Destroy(other.gameObject);
            }
        }
    }
}
