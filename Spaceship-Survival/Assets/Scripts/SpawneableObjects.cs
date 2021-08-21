using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipSurvival
{
    [CreateAssetMenu(fileName = "SpawneableObjects")]
    public class SpawneableObjects : ScriptableObject
    {
        [Header("Enemies")]
        public GameObject eKamikaze;
        public GameObject eSniper;
        public GameObject eCrazy;



        public GameObject GetEnemyByType(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.CRAZY:
                    return eCrazy;
                    break;
                case EnemyType.SNIPER:
                    return eSniper;
                    break;
                case EnemyType.KAMIKAZE:
                    return eKamikaze;
                    break;
                case EnemyType.NOT_DEFINED:
                    Debug.LogError("Calling a not defined enemy");
                    return null;
                    break;
            }

            return null;
        }
    }
}

