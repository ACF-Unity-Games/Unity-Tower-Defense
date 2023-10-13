using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class TowerShooter : MonoBehaviour
{

    [Header("Prefab Assignments")]
    public GameObject BulletPrefab;
    [Header("Tower Properties")]
    [Range(10, 60)]
    public float BulletMoveSpeed = 20;
    [Range(0.1f, 3f)]
    public float ReloadSpeed = 0.5f;

    private bool _isPlaced = false;
    private List<Transform> _enemiesColliding = new List<Transform>();
    private float _currReloadTime;

    private void Awake()
    {
        Debug.Assert(BulletPrefab.GetComponent<BulletHandler>() != null, "BulletPrefab attached requires a BulletHandler!", this);   
    }
    public void Initialize()
    {
        Debug.Log("Tower has been placed!");
        _isPlaced = true;
    }

    // If an enemy is colliding, add it to the enemies colliding list.
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            _enemiesColliding.Add(col.gameObject.transform);
        }
    }

    // If an enemy is no longer colliding, remove it.
    public void OnTriggerExit2D(Collider2D col)
    {
        _enemiesColliding.Remove(col.gameObject.transform);
    }

    public void Update()
    {
        if (!_isPlaced) return;
        if (_enemiesColliding.Count > 0)
        {
            // Look at first enemy colliding
            Transform firstEnemy = _enemiesColliding[0];
            transform.right = firstEnemy.position - transform.position;
            // Check reload time if we can shoot
            _currReloadTime += Time.deltaTime;
            if (_currReloadTime > ReloadSpeed)
            {
                _currReloadTime = 0;
                GameObject b = Instantiate(BulletPrefab, transform.position, transform.rotation);
                b.GetComponent<BulletHandler>().Initialize(BulletMoveSpeed);
                Debug.Log("Shoot!");
            }
        }
    }

}