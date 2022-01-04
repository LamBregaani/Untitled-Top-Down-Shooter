using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTargetOnDestroy : MonoBehaviour
{
    private StoreTarget storeTargetScript;
    private IUpdateTarget updateTargetScript;


    private void Awake()
    {
        RemoveTargetsFromLists.DestroyObject += RemoveTarget;
        storeTargetScript = GetComponent<StoreTarget>();
        if (storeTargetScript == null)
        {
            Debug.Log("No Target storage found!");
        }
        updateTargetScript = GetComponent<IUpdateTarget>();
        if (updateTargetScript == null)
        {
            Debug.Log("No Update Target found!");
        }
    }

    private void OnEnable()
    {
        
    }


    private void RemoveTarget(GameObject targetToRemove)
    {
        storeTargetScript.targets.Remove(targetToRemove);
        updateTargetScript.UpdateTarget();
    }

}
