using System;
using UnityEngine;

namespace SpaceShipSurvival
{
    [Serializable]
    [CreateAssetMenu(menuName = "Upgrades/Shield")]
    public class Shield : Upgrade
    {
        public override void Upgrading()
        {
            PlayerStats.Instance.IncreaseMaxShield();
        }
    }
}