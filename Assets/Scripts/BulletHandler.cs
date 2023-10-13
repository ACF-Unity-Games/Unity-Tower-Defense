using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletHandler : MonoBehaviour
{

    private float _bulletMoveSpeed;
    private bool _isInitialized = false;

    public void Initialize(float moveSpeed)
    {
        _bulletMoveSpeed = moveSpeed;
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
            Debug.Log("Dealt damage to enemy!");
            Destroy(gameObject);
        }
    }

}
