using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IdamageableByPlayer<float>
{
    [System.Serializable]
    public class EnemyHealthChangedEvent : UnityEvent<Stat> { }

    [SerializeField]private Stat health;

    private ITarget targetSystem;

    [SerializeField] public EnemyHealthChangedEvent EnemyHealthChanged;

    [SerializeField] private UnityEvent Killed;


    // Start is called before the first frame update
    void Start()
    {
        health.SetHealthStart();
    }

    public void TakeDamage(float damageTaken)
    {
        health.CurrentValue -= damageTaken;
        EnemyHealthChanged.Invoke(health);
        
        if (health.CurrentValue <= 0)
        {
            Killed.Invoke();
            Destroy(gameObject, 0.1f);
        }
    }
}
