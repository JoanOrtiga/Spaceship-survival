using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival.Upgrades
{
    [CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/Upgrades", order = 0)]
    public class Upgrades : ScriptableObject
    {
        public List<Upgrade> upgrades = new List<Upgrade>();
    }
}