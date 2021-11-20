using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private GameObject _upgradeButtonPrefab;
        [SerializeField] private Transform _upgradeButtonsParent;
        
        [SerializeField] private Button _shopButton;
        [SerializeField] private GameObject _shopPanel;
        
        private bool _showingPanel = false;

        [SerializeField] private Upgrades.Upgrades _upgrades;

        private void Awake()
        {
            RoundController.Instance.RoundChangeState += RoundChangeState;
            _shopPanel.SetActive(false);
            
            GenerateButtonUpgrades();
        }
        
        public void GenerateButtonUpgrades()
        {
            foreach (var upgrade in _upgrades.upgrades)
            {
                GameObject newUpgradeButton = Instantiate(_upgradeButtonPrefab, _upgradeButtonsParent);
                newUpgradeButton.GetComponentsInChildren<Image>()[1].sprite = upgrade.icon;
                Button button = newUpgradeButton.GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    upgrade.Upgrading();
                    //Actualitzar el text de la ui al nou preu. 
                });
            }
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