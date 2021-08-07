using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Kit : MonoBehaviour
    {
        public int Health;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Character>().IncreaseHealth(Health);
                Destroy(gameObject);
            }
        }
    }
}
