using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;

        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void Update()
        {
            _healthBar.fillAmount = (float)_character.GetCurrentHealth() / (float)_character.maxHealth;
        }
    }
}
