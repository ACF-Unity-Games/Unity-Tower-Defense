using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo
{
    public EnemyInfo EnemyInfo;
    [Tooltip("Time (in seconds) the enemy should spawn at")]
    public float TimeBetweenSpawns;
}

public class EnemySpawner : MonoBehaviour
{

    [Header("Prefab Assignments")]
    public GameObject EnemyPrefab;
    [Header("Enemy Spawn Information")]
    public List<EnemySpawnInfo> EnemiesToSpawn;

    private void Awake()
    {
        Debug.Assert(EnemyPrefab.GetComponent<EnemyHandler>() != null, "Enemy prefab must have an enemy handler!", this);
    }

    public void Start()
    {
        foreach (EnemySpawnInfo enemy in EnemiesToSpawn)
        {
            StartCoroutine(SpawnEnemyAtInterval(enemy));
        }
    }

    private IEnumerator SpawnEnemyAtInterval(EnemySpawnInfo enemySpawnInfo)
    {
        yield return new WaitForSeconds(enemySpawnInfo.TimeBetweenSpawns);
        GameObject enemyObject = Instantiate(EnemyPrefab);
        enemyObject.GetComponent<EnemyHandler>().Initialize(enemySpawnInfo.EnemyInfo);
        enemyObject.transform.position = new Vector3(Random.Range(-4f, 4), Random.Range(-2f, 2), 0);
        StartCoroutine(SpawnEnemyAtInterval(enemySpawnInfo));
    }

}
