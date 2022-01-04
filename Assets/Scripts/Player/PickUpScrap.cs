using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScrap : MonoBehaviour
{
    private float scrapAmount;

    private Scrap scrapObject;


    private void OnTriggerEnter(Collider other)
    {
        scrapObject = other.GetComponent<Scrap>();
        if(scrapObject != null)
        {
            scrapAmount += scrapObject.ScrapValue;
            Destroy(other.gameObject);
        }
    }


    
}
