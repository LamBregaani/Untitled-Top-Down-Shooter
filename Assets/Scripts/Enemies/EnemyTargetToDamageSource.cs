using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetToDamageSource : MonoBehaviour, ITarget
{

    private GameObject core;

    private float currentTime;

    private void Awake()
    {
        core = GameObject.FindObjectOfType<CoreController>().gameObject;
        SetTargetToCore();
    }

    public void SetTarget(GameObject target)
    {
        SetTargetToObject(target);
        currentTime = Time.time;
    }


    private void SetTargetToCore()
    {
        
        SetTarget(core);
        Debug.Log("Current target is the core!");
    }

    private void SetTargetToObject(GameObject target)
    {
        Debug.Log("Current target is the " + target.name);
        if (Time.time >= currentTime + 10)
            SetTargetToCore();
    }



}
