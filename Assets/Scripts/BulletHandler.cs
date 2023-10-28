using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletHandler : MonoBehaviour
{

    private bool _isInitialized = false;
    private BulletInfo _bulletInfo;

    private SpriteRenderer _spriteRenderer;

    private List<Collider2D> _enemiesDamaged = new();

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(BulletInfo bulletInfo)
    {
        _bulletInfo = bulletInfo;
        _spriteRenderer.sprite = bulletInfo.BulletSprite;
        transform.localScale = bulletInfo.BulletScale;
        _isInitialized = true;
        StartCoroutine(DestroyAfterTime(bulletInfo.BulletLifetime));
    }

    private void Update()
    {
        if (!_isInitialized) return;
        transform.Translate(_bulletInfo.BulletMoveSpeed * Time.deltaTime, 0, 0);
    }

    private IEnumerator DestroyAfterTime(float lifetimeInSecs)
    {
        yield return new WaitForSeconds(lifetimeInSecs);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !_enemiesDamaged.Contains(collision))
        {
            _enemiesDamaged.Add(collision);
            HealthHandler healthHandler = collision.gameObject?.GetComponent<HealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.CurrentHealth -= _bulletInfo.BulletDamage;
            }
            if (_enemiesDamaged.Count >= Mathf.Max(1, _bulletInfo.BulletPierce))
            {
                Destroy(gameObject);
            }
        }
    }

}
