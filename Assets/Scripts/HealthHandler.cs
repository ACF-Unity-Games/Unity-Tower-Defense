using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{

    [Header("Health Information")]
    [SerializeField] private int _currentHealth;
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            Debug.Log("Took damage! Now at " + _currentHealth.ToString() + " HP");
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        CurrentHealth = 10;
    }

}