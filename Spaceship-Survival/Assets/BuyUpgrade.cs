using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class BuyUpgrade : MonoBehaviour
    {
        private int _currentUpgrade = 0;

        private int[] _increaseAmount = new int[]
        {
            10, 50, 100
        };
        
        private int[] _price = new int[]
        {
            500, 1000, 1500, 2500
        };

        private PlayerStats _playerStats;
        
        private void Awake()
        {
            _playerStats = SceneReferences.Instance.Player.GetComponent<PlayerStats>();
        }

        public void TryBuying()
        {
            if (_playerStats.WasteCoins(_price[_currentUpgrade]))
            {
                //_playerStats.IncreaseDamage(_increaseAmount[_currentUpgrade]);
                _currentUpgrade++;
                return;
            }
            
            //Animation no tens mes diners.
        }
    }
}
