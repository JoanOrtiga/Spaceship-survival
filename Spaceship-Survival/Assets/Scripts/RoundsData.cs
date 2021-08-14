using System.Collections.Generic;
using UnityEngine;

namespace RoundsMaker
{
    [CreateAssetMenu(fileName = "RoundsData", menuName = "Rounds/RoundsData")]
    public class RoundsData : ScriptableObject
    {
        public List<Round> rounds = new List<Round>();
    }

    [System.Serializable]
    public struct Round
    {
        public List<SpawnEnemy> enemies;
        public float maxRoundTime;

        public Round(List<SpawnEnemy> enemies, float maxRoundTime)
        {
            this.enemies = enemies;
            this.maxRoundTime = maxRoundTime;
        }
    }

    [System.Serializable]
    public struct SpawnEnemy
    {
        public EnemyType enemyType;
        public Vector3 spawnPoint;
        public int quantity;
        public float timeBetweenSpawns;
        public float timeToStartSpawning;

        public SpawnEnemy(Vector3 spawnPoint, EnemyType enemyType = EnemyType.ROUND, int quantity = 0, float timeBetweenSpawns = 0.0f,
            float timeToStartSpawning = 0.0f)
        {
            this.enemyType = enemyType;
            this.spawnPoint = spawnPoint;
            this.quantity = quantity;
            this.timeBetweenSpawns = timeBetweenSpawns;
            this.timeToStartSpawning = timeToStartSpawning;
        }
    }
}