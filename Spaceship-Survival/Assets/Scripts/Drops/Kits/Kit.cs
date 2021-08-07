using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Kit : MonoBehaviour
    {
        public int health;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Character>().IncreaseHealth(health);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
