using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObject : MonoBehaviour
{
    [SerializeField] private GameObject testBuilding;

    [ContextMenu("Test Build")]
    void Test()
    {
        Build(testBuilding);
    }


    public void Build(GameObject building)
    {

        float colliderScaleY = transform.lossyScale.y / 4;
        float colliderPositionY = transform.position.y;
        colliderPositionY += colliderScaleY;

        float spawnObjectScaleY = building.transform.lossyScale.y / 2;

        spawnObjectScaleY += colliderPositionY;

        var newBuilding = Instantiate(building, new Vector3(transform.position.x, spawnObjectScaleY, transform.position.z), Quaternion.identity);
        newBuilding.transform.parent = gameObject.transform;
        print("Building Spawned!");
    }
}
