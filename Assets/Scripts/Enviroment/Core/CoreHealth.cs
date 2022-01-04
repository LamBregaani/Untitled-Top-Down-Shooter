using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreHealth : MonoBehaviour, IdamageableByEnemy<float>
{
    [System.Serializable]
    public class HealthChangedEvent : UnityEvent<float, float> { }


    [SerializeField] private float maxHealth;
    private float currentHealth;


    [SerializeField] public HealthChangedEvent HealthChanged;

    public bool hasUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        OnHealthChanged();
        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    private void OnHealthChanged()
    {
        HealthChanged.Invoke(currentHealth, maxHealth);
    }
}
