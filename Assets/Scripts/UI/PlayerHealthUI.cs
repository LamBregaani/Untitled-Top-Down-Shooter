using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image playerHealthSprite;



    private void OnEnable()
    {
        //PlayerHealth.HealthBarCreated += UpdateEnemyHealthBar;

        //CreateCoreHealthBar.CoreHealthBarCreated += UpdateEnemyHealthBar;
    }

    private void OnDisable()
    {
        //CreateEnemyHealthBar.HealthBarCreated -= UpdateEnemyHealthBar;

        //CreateCoreHealthBar.CoreHealthBarCreated -= UpdateEnemyHealthBar;
    }

    public void PlayerHealthChanged(float currentHealth, float maxHealth)
    {
        Debug.Log("Health Changed!");
        playerHealthSprite.fillAmount = currentHealth / maxHealth;
    }
}
