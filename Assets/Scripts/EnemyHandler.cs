using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HealthHandler))]
public class EnemyHandler : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _healthHandler = GetComponent<HealthHandler>();
    }

    public void Initialize(EnemyInfo enemyInfo)
    {
        transform.localScale = enemyInfo.EnemyScale;
        _spriteRenderer.sprite = enemyInfo.EnemySprite;
        _healthHandler.CurrentHealth = enemyInfo.EnemyHealth;
    }

}
