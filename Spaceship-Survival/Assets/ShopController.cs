using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private Button _shopButton;
        [SerializeField] private GameObject _shopPanel;


        private bool _showingPanel = false;

        private void Awake()
        {
            RoundController.Instance.RoundChangeState += RoundChangeState;
            _shopPanel.SetActive(false);
        }

        public void RoundChangeState(bool roundActive)
        {
            if (roundActive)
            {
                _shopButton.interactable = false;
                _shopPanel.SetActive(false);
                _showingPanel = false;
            }
            else
            {
                _shopButton.interactable = true;
            }
        }

        public void ShowShopPanel()
        {
            _showingPanel = !_showingPanel;
            _shopPanel.SetActive(_showingPanel);
        }
    }
}
