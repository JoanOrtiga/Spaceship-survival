using System;
using System.Collections;
using System.Collections.Generic;
using SpaceShipSurvival;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerController : Character
    {
        private PlayerMovement _playerMovement;
        private PlayerShooting _playerShooting;
        private PlayerStats _playerStats;

        private event Action onPlayerDead;

        public Action OnPlayerDead
        {
            get => onPlayerDead;
            set => onPlayerDead = value;
        }

        protected override void Awake()
        {
            base.Awake();

            _playerStats = GetComponent<PlayerStats>();
            _playerStats.OnMaxHealthChanged += UpdateMaxHealth;
        }

        public void UpdateMaxHealth(float maxHealth)
        {
            base.maxHealth = int.Parse(maxHealth.ToString());
        }

        private void OnDestroy()
        {
            _playerStats.OnMaxHealthChanged -= UpdateMaxHealth;
            OnPlayerDead.Invoke();
        }
    }
}
