using System;
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
        
        [SerializeField] private float _damage = 10;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _maxShield = 0;
        [SerializeField] private float _speed = 30;
        [SerializeField] private int _coins = 0;
        [SerializeField] private bool _autoCollection = false;

        public Action<int> UpdatePlayerHealth { get; set; }

        private event Action<int> _onCoinUpdate;

        public event Action<int> OnUpdateCoin
        {
            add => _onCoinUpdate += value;
            remove => _onCoinUpdate -= value;
        }

        private void Awake()
        {
            Instance = this;
        }

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