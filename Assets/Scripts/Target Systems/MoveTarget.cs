using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public void Move()
    {
        Vector3 pos = new Vector3(-1000, -1000, -1000);
        transform.position = pos;
    }
}
