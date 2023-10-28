using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Instance;
    [Header("Prefab Assignments")]
    public GameObject EnemyPrefab;
    [Header("Object Assignments")]
    public Transform SpawnParentTransform;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    private void Awake()
    {
        Debug.Assert(SpawnParentTransform != null, "Parent to store objects cannot be null!", this);
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void CreateNewEnemy()
    {
        GameObject enemyObject = Instantiate(EnemyPrefab);
        enemyObject.transform.SetParent(SpawnParentTransform);
        enemyObject.SetActive(false);
        enemyPool.Enqueue(enemyObject);
    }

    public GameObject GetEnemyObject()
    {
        if (enemyPool.Count == 0) CreateNewEnemy();
        GameObject enemyObject = enemyPool.Dequeue();
        enemyObject.SetActive(true);
        return enemyObject;
    }

    public void ReturnEnemyToPool(GameObject enemyObject)
    {
        enemyObject.transform.SetParent(SpawnParentTransform);
        enemyObject.SetActive(false);
        enemyPool.Enqueue(enemyObject);
    }

}
