using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class TurretAOEAttack : MonoBehaviour, IUpdateTarget
{

    private Transform currentTarget;

    private StoreTarget storeTargetList;




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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (currentTarget != null)
        {

            fireAllWeaponsScript.canFire = true;
        }
        else
        {
            fireAllWeaponsScript.canFire = false;
        }


    }




    public void UpdateTarget()
    {
        if (storeTargetList.targets.Count != 0)
        {
            currentTarget = storeTargetList.targets[0].transform;
        }

    }

        
}
