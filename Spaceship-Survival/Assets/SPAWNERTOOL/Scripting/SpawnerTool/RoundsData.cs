using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundsData", menuName = "Rounds/RoundsData")]
public class RoundsData : ScriptableObject
{
    public List<EnemyRound> rounds = new List<EnemyRound>();
}

[System.Serializable]
public struct EnemyRound
{
    public List<SpawningEnemy> spawningEnemies;
    public float totalRoundTime;

    //Tool Purposes
    public int totalTracks;

    public EnemyRound(List<SpawningEnemy> spawningEnemies = null, float totalRoundTime = default,
        int totalTracks = default)
    {
        if (spawningEnemies == null)
        {
            this.spawningEnemies = new List<SpawningEnemy>();
        }
        else
            this.spawningEnemies = spawningEnemies;

        this.totalRoundTime = totalRoundTime;
        this.totalTracks = totalTracks;
    }

    public void InitializeSpawningEnemies(List<SpawningEnemy> spawningEnemies)
    {
        this.spawningEnemies = spawningEnemies;
    }
}

[System.Serializable]
public struct SpawningEnemy
{
    public int spawnPointID;
    public float timeToStartSpawning;
    public int howManyEnemies;
    public EnemyType enemyType;
    public float timeBetweenSpawn;

    //Tracks
    public int currentTrack;

    public SpawningEnemy(int spawnPointID = 1, float timeToStartSpawning = 0, int howManyEnemies = 5,
        EnemyType enemyType = EnemyType.NOT_DEFINED, float timeBetweenSpawn = 1)
    {
        this.spawnPointID = spawnPointID;
        this.timeToStartSpawning = timeToStartSpawning;
        this.howManyEnemies = howManyEnemies;
        this.enemyType = enemyType;
        this.timeBetweenSpawn = timeBetweenSpawn;
        this.currentTrack = 0;
    }
}