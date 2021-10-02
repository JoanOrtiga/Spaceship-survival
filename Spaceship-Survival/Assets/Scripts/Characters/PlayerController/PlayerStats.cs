using System;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _maxShield = 0;
        [SerializeField] private float _speed = 30;

        public Action<int> UpdatePlayerHealth { get; set; }
        
        public void IncreaseDamage()
        {
            _damage += 5;
            UpdatePlayerHealth.Invoke(Mathf.RoundToInt(_damage));
        }

        public void IncreaseMaxHealth()
        {
            
        }

        public void InreaseMaxShield()
        {
            
        }

        public void IncreaseSpeed()
        {
            
        }       
    }
}
