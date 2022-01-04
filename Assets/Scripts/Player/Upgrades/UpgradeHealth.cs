using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHealth : MonoBehaviour
{

    private PlayerHealth playerSpeedScript;

    [SerializeField] private float healthMulti;

    private void Awake()
    {
        playerSpeedScript = FindObjectOfType<PlayerHealth>();
    }

    public void NewHealth()
    {
        //playerSpeedScript.SetHealthBonus(healthMulti);

    }
}
