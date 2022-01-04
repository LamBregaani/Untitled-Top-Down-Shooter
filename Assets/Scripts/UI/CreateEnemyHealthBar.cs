using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyHealthBar : MonoBehaviour
{
    private bool hasUI;

    [SerializeField] private GameObject healthBarObj;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float healthBarLifeTime;

    private float healthBarLifeTimeStart;

    public static event Action<GameObject> HealthBarCreated = delegate { };


    private GameObject spawnedHealthBar;

    private Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }
    private void LateUpdate()
    {
        if (spawnedHealthBar)
        {
            spawnedHealthBar.transform.position = cam.WorldToScreenPoint(transform.position + offset);
            if(Time.time >= healthBarLifeTimeStart + healthBarLifeTime)
            {
                hasUI = false;
                DestroyHealthBar();
            }
        }
    }

    public void DestroyHealthBar() => Destroy(spawnedHealthBar);

    public void EnemyHealthBar(Stat health)
    {
        if(!hasUI)
        {
            hasUI = true;
            spawnedHealthBar = Instantiate(healthBarObj, transform.position, Quaternion.identity);
            HealthBarCreated(spawnedHealthBar);
        }
        var healthUI = spawnedHealthBar.GetComponentInChildren<Image>();
        healthUI.fillAmount = health.CurrentValue / health.MaxValue;
        healthBarLifeTimeStart = Time.time;
    }





}
