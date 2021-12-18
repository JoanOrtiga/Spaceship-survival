using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class Character : MonoBehaviour
    {
        public int maxHealth = 100;
        private int _currentHealth;

        private bool damageable = true;
        
        [SerializeField] private DropData dropData;

        protected virtual void Awake()
        {
            _currentHealth = maxHealth;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void LoseHealth(int damage)
        {
            if (damageable is false)
                return;

            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                if(!gameObject.CompareTag("Player"))
                    Die();
            }
        }

        public void IncreaseHealth(int health)
        {
            if (_currentHealth + health < maxHealth) 
            {
                int x;
                x = (_currentHealth + health) - maxHealth;
                health -= x;
            }
                
            _currentHealth += health;
        }

        private void Die()
        {
            //Instancia particules d'explosió.

            dropData.Drop(gameObject.transform.position);

            Destroy(gameObject, 0.1f);
        }
    } 
}

