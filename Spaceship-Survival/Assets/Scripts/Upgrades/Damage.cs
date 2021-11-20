using System;
using SpaceShipSurvival;
using UnityEngine;

[Serializable][CreateAssetMenu(menuName = "Upgrades/Damage")]
public class Damage : Upgrade
{
    public override void Upgrading()
    {
        PlayerStats.Instance.IncreaseDamage();
    }
}