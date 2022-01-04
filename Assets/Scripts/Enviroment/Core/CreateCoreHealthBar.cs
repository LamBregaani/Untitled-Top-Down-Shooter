using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCoreHealthBar : MonoBehaviour
{


    [SerializeField] private GameObject healthBarObj;

    [SerializeField] private Vector3 offset;

    public static event Action<GameObject> CoreHealthBarCreated = delegate { };

    private GameObject spawnedHealthBar;

    private Camera cam;

    private void Awake()
    {
        spawnedHealthBar = Instantiate(healthBarObj, transform.position, Quaternion.identity);
        cam = FindObjectOfType<Camera>();
        
    }

    private void Start()
    {
        CoreHealthBarCreated(spawnedHealthBar);
        spawnedHealthBar.transform.position = cam.WorldToScreenPoint(transform.position + offset);
    }

    private void LateUpdate()
    {

        spawnedHealthBar.transform.position = cam.WorldToScreenPoint(transform.position + offset);

    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        var health = spawnedHealthBar.GetComponentInChildren<Image>();
        health.fillAmount = currentHealth / maxHealth;
    }




    public void DestroyHealthBar()
    {
        Destroy(spawnedHealthBar);
    }
}
