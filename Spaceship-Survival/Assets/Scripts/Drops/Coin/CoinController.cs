using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private int coins = 0;
        public CoinText coinText;
        public PlayerStats playerStats;

        public void Coin(int collectedCoins)
        {
            coins = coins + collectedCoins;

            coinText.ChangeTextCoin(coins);
            playerStats.TotalCoins(coins);
        }
    }
}
