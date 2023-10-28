using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthHandler))]
public class EnemyHandler : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private HealthHandler _healthHandler;

    public Action OnDeath;

    private List<EnemyDeathInfo> _enemiesToSpawnOnDeath;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthHandler = GetComponent<HealthHandler>();
        OnDeath += SpawnDeathEnemies;
    }

    public void Initialize(EnemyInfo enemyInfo)
    {
        transform.localScale = enemyInfo.EnemyScale;
        _spriteRenderer.sprite = enemyInfo.EnemySprite;
        _healthHandler.CurrentHealth = enemyInfo.EnemyHealth;
    }

    private void SpawnDeathEnemies()
    {
        foreach (EnemyDeathInfo enemy in _enemiesToSpawnOnDeath)
        {
            for (int i = 0; i < enemy.EnemyCount; i++)
            {
                GameObject enemyObject = ObjectPooler.Instance.GetEnemyObject();
                enemyObject.GetComponent<EnemyHandler>().Initialize(enemy.EnemyInfo);
                enemyObject.transform.position = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            }
        }
    }

}
