using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Character : MonoBehaviour
    {
        public int maxHealth = 100;
        private int currentHealth;

        private bool damageable = true;
        
        [SerializeField] private DropData dropData;

        protected virtual void Awake()
        {
            currentHealth = maxHealth;
        }

        public void LoseHealth(int damage)
        {
            if (damageable is false)
                return;

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                if(!gameObject.CompareTag("Player"))
                    Die();
            }
        }

        public void IncreaseHealth(int health)
        {
            if (currentHealth + health < maxHealth) 
            {
                int x;
                x = (currentHealth + health) - maxHealth;
                health -= x;
            }
                
            currentHealth += health;
        }

        private void Die()
        {
            //Instancia particules d'explosió.

            dropData.Drop(gameObject.transform.position);

            Destroy(gameObject, 0.1f);
        }
    } 
}

