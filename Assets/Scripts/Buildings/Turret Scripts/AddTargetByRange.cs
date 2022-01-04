using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTargetByRange : MonoBehaviour
{


    

    private StoreTarget storeTargetList;

    private IUpdateTarget updateTargetScript;

    private void Awake()
    {
        storeTargetList = GetComponent<StoreTarget>();
        if (storeTargetList == null)
        {
            Debug.Log("No Target storage found!");
        }
        updateTargetScript = GetComponent<IUpdateTarget>();
        if (updateTargetScript == null)
        {
            Debug.Log("No Update Target found!");
        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<EnemyHealth>().gameObject != null)
        {
            GameObject newTarget = other.gameObject;
            storeTargetList.targets.Add(newTarget);
            updateTargetScript.UpdateTarget();
        }

    }
}
