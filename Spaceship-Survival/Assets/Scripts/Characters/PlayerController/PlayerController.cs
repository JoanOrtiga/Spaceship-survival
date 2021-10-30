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
            _playerStats.UpdatePlayerHealth += UpdateMaxHealth;
        }

        public void UpdateMaxHealth(int maxHealth)
        {
            base.maxHealth = maxHealth;
        }

        private void OnDestroy()
        {
            OnPlayerDead.Invoke();
        }
    }
}
