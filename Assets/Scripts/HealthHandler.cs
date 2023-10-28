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
            if (_currentHealth <= 0)
            {
                transform.Translate(0, 100, 0);
                // TODO: Make this not specific to enemies!
                GetComponent<EnemyHandler>().OnDeath.Invoke();
                StartCoroutine(ReturnAfterDelay());
            }
        }
    }

    private IEnumerator ReturnAfterDelay()
    {
        yield return new WaitForEndOfFrame();
        ObjectPooler.Instance.ReturnEnemyToPool(gameObject);
    }

}
