using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnemyHealthUI : MonoBehaviour
 {
    private List<GameObject> healthBars;



    [SerializeField] private GameObject enemyHealthBarParent;

    private void OnEnable()
    {
        CreateEnemyHealthBar.HealthBarCreated += UpdateEnemyHealthBar;

        CreateCoreHealthBar.CoreHealthBarCreated += UpdateEnemyHealthBar;
    }

    private void OnDisable()
    {
        CreateEnemyHealthBar.HealthBarCreated -= UpdateEnemyHealthBar;

        CreateCoreHealthBar.CoreHealthBarCreated -= UpdateEnemyHealthBar;
    }




    public void UpdateEnemyHealthBar(GameObject healthBar)
    {
        healthBar.transform.SetParent(enemyHealthBarParent.transform);

        //healthBars.Add(healthBar);
    }
}
