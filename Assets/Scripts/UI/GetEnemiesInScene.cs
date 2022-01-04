using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemiesInScene : MonoBehaviour
{
    //public List<GameObject>[] enemies;

    [SerializeField] private GameObject healthBarUI;

    [SerializeField] private GameObject healthBarUIParent;

    private Camera cam;

    GameObject healthBar;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void LateUpdate()
    {
        /*var allEnemies = FindObjectsOfType<CoreHealth>();
        foreach (var core in allEnemies)
        {
            if(!core.hasUI)
            {
                core.hasUI = true;
                GameObject healthBar = Instantiate(healthBarUI, transform.position, Quaternion.identity, healthBarUIParent.transform);
                
            }
            healthBar.transform.position = cam.WorldToScreenPoint(core.transform.position);
        }*/

        var coreScript = FindObjectOfType<CoreHealth>();
        if (!coreScript.hasUI)
        {
            coreScript.hasUI = true;
            healthBar = Instantiate(healthBarUI, transform.position, Quaternion.identity, healthBarUIParent.transform);

        }
        healthBar.transform.position = cam.WorldToScreenPoint(coreScript.transform.position);
    }
}
