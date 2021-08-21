using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    NOT_DEFINED = 0, KAMIKAZE, SNIPER, CRAZY
}

namespace SpaceShipSurvival
{
    public class Enemy : Character
    {
        public EnemyType enemyType = EnemyType.SNIPER;
    }
}


