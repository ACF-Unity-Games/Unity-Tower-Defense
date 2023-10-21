using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletHandler : MonoBehaviour
{

    private int _bulletDamage;
    
    private float _bulletMoveSpeed;
    private bool _isInitialized = false;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(Sprite bulletSprite, float moveSpeed, int damage)
    {
        _spriteRenderer.sprite = bulletSprite;
        _bulletMoveSpeed = moveSpeed;
        _bulletDamage = damage;
        _isInitialized = true;
    }

    private void Update()
    {
        if (!_isInitialized) return;
        transform.Translate(_bulletMoveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HealthHandler healthHandler = collision.gameObject?.GetComponent<HealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.CurrentHealth -= _bulletDamage;
            }
            Debug.Log("Dealt damage to enemy!");
            Destroy(gameObject);
        }
    }

}
