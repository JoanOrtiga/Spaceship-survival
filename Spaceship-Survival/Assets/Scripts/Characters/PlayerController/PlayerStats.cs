using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerStats : MonoBehaviour
    {
        private static PlayerStats _instance;

        public static PlayerStats Instance
        {
            get
            {
                if (_instance is null)
                {
                    PlayerStats stats = FindObjectOfType<PlayerStats>();
                    
                    if (stats != null)
                    {
                        _instance = stats;
                        return _instance;
                    }
                    
                    GameObject playerStats = new GameObject();
                    PlayerStats._instance = playerStats.AddComponent<PlayerStats>();
                }

                return _instance;
            }
            private set
            {
                if (_instance != null)
                {
                    Destroy(value);
                    return;
                }

                _instance = value;
            }
        }

        
        [SerializeField] private Damage damage;
        [SerializeField] private int _damageLevel = 0;
        public event Action<float> DamageChanged;
        public void IncreaseDamage()
        {
            _damageLevel++;
            DamageChanged?.Invoke(GetDamage);
        }
        public float GetDamage => damage.values[_damageLevel].increaseValue;

        [SerializeField] private Health health;
        [SerializeField] private int _healthLevel = 0;
        public event Action<float> OnMaxHealthChanged;
        public void IncreaseMaxHealth()
        {
            _healthLevel++;
            OnMaxHealthChanged?.Invoke(GetHealth);
        }
        public float GetHealth
        {
            get
            {
                if (health != null)
                {
                    if (health.values != null || health.values.Length != 0)
                    {
                        return health.values[_healthLevel].increaseValue;
                    }
                }

                return 100;
            }
        }

        [SerializeField] private Shield shield;
        [SerializeField] private int _shieldLevel = 0;
        public void IncreaseMaxShield()
        {
            _shieldLevel++;
        }
        public float GetShield => shield.values[_shieldLevel].increaseValue;
        
        
        [SerializeField] private float _maxShield = 0;
        [SerializeField] private float _speed = 30;
        [SerializeField] private int _coins = 0;
        [SerializeField] private bool _autoCollection = false;

        private event Action<int> _onCoinUpdate;

        public event Action<int> OnUpdateCoin
        {
            add => _onCoinUpdate += value;
            remove => _onCoinUpdate -= value;
        }
        
        public void AutoCollectCoins()
        {
            if (WasteCoins(1))
            {
                _autoCollection = true;
            }
        }

        public bool WasteCoins(int coins)
        {
            if (_coins - coins < 0)
            {
                return false;
            }

            _coins -= coins;
            _onCoinUpdate?.Invoke(_coins);
            return true;
        }

        public void AddCoins(int coinsToAdd)
        {
            _coins += coinsToAdd;
            _onCoinUpdate?.Invoke(_coins);
        }
    }
}