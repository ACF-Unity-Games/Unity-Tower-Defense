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

    public void Initialize(BulletInfo bulletInfo)
    {
        _spriteRenderer.sprite = bulletInfo.BulletSprite;
        _bulletMoveSpeed = bulletInfo.BulletMoveSpeed;
        _bulletDamage = bulletInfo.BulletDamage;
        _isInitialized = true;
        StartCoroutine(DestroyAfterTime(bulletInfo.BulletLifetime));
    }

    private void Update()
    {
        if (!_isInitialized) return;
        transform.Translate(_bulletMoveSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator DestroyAfterTime(float lifetimeInSecs)
    {
        yield return new WaitForSeconds(lifetimeInSecs);
        Destroy(gameObject);
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
            Destroy(gameObject);
        }
    }

}
