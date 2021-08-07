using UnityEngine;

namespace SpaceShipSurvival
{
    public class Enemy : Character
    {
        public enum EnemyType
        {
            SQUARED = 0, ROUND, TRIANGULAR
        }

        public EnemyType enemyType = EnemyType.ROUND;
    }
}

