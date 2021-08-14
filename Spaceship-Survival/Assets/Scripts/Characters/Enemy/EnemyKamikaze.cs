using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace SpaceShipSurvival
{
    public class EnemyKamikaze : Enemy
    {
        protected override void Awake()
        {
            enemyType = EnemyType.KAMIKAZE;
            base.Awake();
            GetComponent<AIDestinationSetter>().target = SpaceShipLogic.GetLogic().player.transform;
        }
    }
}

