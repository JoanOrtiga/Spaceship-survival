using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class PlayerController : Character
    {
        private PlayerMovement _playerMovement;
        private PlayerShooting _playerShooting;
        private PlayerStats _playerStats;

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
    }
}