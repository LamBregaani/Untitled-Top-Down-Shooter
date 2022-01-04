using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class TurretTrackTarget : MonoBehaviour, IUpdateTarget
{

    private Transform currentTarget;

    private StoreTarget storeTargetList;

    
    [SerializeField] private float rotateSpeed;

    private AutoFireAllWeapons fireAllWeaponsScript;


    private void Awake()
    {
        fireAllWeaponsScript = GetComponent<AutoFireAllWeapons>();


        storeTargetList = GetComponent<StoreTarget>();
        if (storeTargetList == null)
        {
            Debug.Log("No Target storage found!");
        }
    }


    // Update is called once per frame
    void Update()
    {




        if (currentTarget != null)
        {
            
            Vector3 targetDirection = currentTarget.position - transform.position;
            
            float singleStep = rotateSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            fireAllWeaponsScript.canFire = true;
        }
        else
        {
            fireAllWeaponsScript.canFire = false;
        }


    }




    public void UpdateTarget()
    {
        if(storeTargetList.targets.Count != 0)
        {
            currentTarget = storeTargetList.targets[0].transform;
        }
        
    }
}
