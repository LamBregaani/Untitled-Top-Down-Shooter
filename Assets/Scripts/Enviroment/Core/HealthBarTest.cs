using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTest : MonoBehaviour
{
    public GameObject healthBar;

    public Camera cam;

    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.transform.position = cam.WorldToScreenPoint(transform.position + offset);
    }
}
