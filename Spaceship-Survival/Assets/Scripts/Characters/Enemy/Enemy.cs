using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    KAMIKAZE = 0, ROUND, TRIANGULAR
}

namespace SpaceShipSurvival
{
    public class Enemy : Character
    {
        public EnemyType enemyType = EnemyType.ROUND;
    }
}


