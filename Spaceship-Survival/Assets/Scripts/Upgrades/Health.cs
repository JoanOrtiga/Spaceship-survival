using System;
using SpaceShipSurvival;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Upgrades/Health")]
public class Health : Upgrade
{
    public override void Upgrading()
    {
       PlayerStats.Instance.IncreaseMaxHealth();
    }
}