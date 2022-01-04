using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class TurretSpin : MonoBehaviour, IUpdateTarget
{
    [SerializeField] private float maxRotateSpeed;

    public float rotateSpeed { get; private set; }


    private bool speedUp;

    private bool reduceSpeed;

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


    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {

            if (speedUp)
            {
                StopAllCoroutines();
                StartCoroutine(SpeedUp());
                speedUp = false;
            }

            
            fireAllWeaponsScript.canFire = true;
        }
        else
        {
            if (reduceSpeed)
            {
                StopAllCoroutines();
                StartCoroutine(ReduceSpeed());
                reduceSpeed = false;
            }
            fireAllWeaponsScript.canFire = false;
        }
        if(rotateSpeed > 0)
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }


    }




    public void UpdateTarget()
    {
        if (storeTargetList.targets.Count != 0)
        {
            if(rotateSpeed == 0)
            {
                speedUp = true;
            }
            
            currentTarget = storeTargetList.targets[0].transform;
        }
        else
        {
            reduceSpeed = true;
        }

    }

    private IEnumerator SpeedUp()
    {
        
        
        for (float i = 0; i < maxRotateSpeed; i += Time.deltaTime * 1000)
        {
            rotateSpeed = i;

            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator ReduceSpeed()
    {
        for (float i = rotateSpeed; i > 0; i -= Time.deltaTime * 800)
        {
            rotateSpeed = i;

            yield return new WaitForEndOfFrame();
        }
        rotateSpeed = 0;
    }
}
