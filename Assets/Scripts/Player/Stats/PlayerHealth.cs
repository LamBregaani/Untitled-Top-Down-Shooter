using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IdamageableByEnemy<float>
{
    [System.Serializable]
    public class PlayerHealthChangedEvent : UnityEvent<float, float> { }

    private float healthMultiplier;

    private float healthPenalty;

    [SerializeField] private Stat health;

    [SerializeField] public PlayerHealthChangedEvent HealthChanged;


    private void Awake()
    {
        //currentHealth = _baseHealth;
        //_maxHealth = _baseHealth;
        health.SetHealthStart();
    }

    void Start()
    {
        //SetHealthBonus(1);
        //SetHealthPenalty(1);
    }



    private void OnTriggerEnter(Collider other)
    {
        var healthOrb = other.GetComponent<HealthOrb>();
        if (healthOrb != null)
        {
            health.CurrentValue += healthOrb.HealthValue;
            OnHealthChanged();
            Destroy(other.gameObject);
        }
    }


    public void TakeDamage(float damageTaken)
    {
        health.CurrentValue -= damageTaken;
        OnHealthChanged();
    }

    private void OnHealthChanged()
    {
        HealthChanged.Invoke(health.CurrentValue, health.MaxValue);
    }

    [ContextMenu("Damage Player")]
    public void DamagePlayer()
    {
        TakeDamage(10);
    }

    /*public void SetHealthBonus(float mulitiplier)
    {
        float tempHealth = health.MaxValue - health.CurrentValue;

        healthMultiplier += mulitiplier;

        //health.maxHealth = _baseHealth * healthMultiplier * healthPenalty;

        currentHealth = health.MaxValue - tempHealth;

        OnHealthChanged();
    }

    public void SetHealthPenalty(float multiplier)
    {
        float tempHealth = health.MaxValue - currentHealth;

        healthPenalty += multiplier;

        //health.maxHealth = _baseHealth * healthMultiplier * healthPenalty;

        currentHealth = health.MaxValue - tempHealth;

        OnHealthChanged();
    }*/

}