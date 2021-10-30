using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival
{
    public class CoinText : MonoBehaviour
    {
        public Text coinText;

        void Start()
        {
            coinText.text = "Coins: \n0";
        }

        public void ChangeTextCoin(int coins)
        {
            coinText.text = "Coins: \n" + coins;
        }
    }
}
