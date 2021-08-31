using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    KAMIKAZE = 0, SNIPER, CRAZY
}

namespace SpaceShipSurvival
{
    public class Enemy : Character
    {
        public EnemyType enemyType = EnemyType.SNIPER;
    }
}


