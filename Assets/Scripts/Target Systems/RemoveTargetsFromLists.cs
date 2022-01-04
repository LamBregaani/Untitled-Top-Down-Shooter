using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTargetsFromLists : MonoBehaviour
{
    public static event Action<GameObject> DestroyObject = delegate { };

    public void OnDestroy()
    {
        DestroyObject(this.gameObject);
    }


}
