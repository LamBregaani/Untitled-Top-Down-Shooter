using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRemoveTargetByRange : MonoBehaviour
{
    private StoreTarget storeTargetList;
    private GameObject removedTarget;

    private IUpdateTarget updateTargetScript;

    private void Awake()
    {
        storeTargetList = GetComponent<StoreTarget>();
        if (storeTargetList == null)
        {
            Debug.Log("No Target storage found!");
        }
        updateTargetScript = GetComponent<IUpdateTarget>();
        if(updateTargetScript == null)
        {
            Debug.Log("No Update Target found!");
        }
    }


    private void OnTriggerExit(Collider other)
    {

        removedTarget = other.GetComponent<EnemyHealth>().gameObject;
        if (removedTarget != null)
        {
            RemoveTarget(removedTarget);
        }
        
    }

    private void RemoveTarget(GameObject target)
    {
        storeTargetList.targets.Remove(target);
        updateTargetScript.UpdateTarget();

    }
}
