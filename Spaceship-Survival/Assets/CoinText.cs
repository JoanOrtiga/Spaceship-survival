using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival
{
    public class CoinText : MonoBehaviour
    {
        public Text coinText;

        private void OnEnable()
        {
            PlayerStats.Instance.OnUpdateCoin += ChangeTextCoin;
        }

        private void OnDisable()
        {
            PlayerStats.Instance.OnUpdateCoin -= ChangeTextCoin;
        }

        void Start()
        {
            coinText.text = "Coins: \n0";
        }

        private void ChangeTextCoin(int coins)
        {
            coinText.text = "Coins: \n" + coins;
        }
    }
}
