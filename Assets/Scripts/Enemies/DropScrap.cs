using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScrap : MonoBehaviour
{

    [System.Serializable]
    public class DropScrapChance
    {
        public GameObject scrapPrefab;
        public float dropChance;
        public int maxDropAmount;
        public int dropChanceDecrease;
    }

    //[SerializeField] private int maxDropAmount;

    //public float maxDropAmountMultiplyer;

    [SerializeField] private DropScrapChance[] scrapObjects;





    private void CalcDropChance(DropScrapChance scrap)
    {
        float tempDropAmount = scrap.dropChance;
        for (float i = 0; i <= scrap.maxDropAmount; i++)
        {
            float tempValue = Random.Range(0, 101);
            if (tempValue <= scrap.dropChance)
                SpawnScrap(scrap.scrapPrefab);
            tempDropAmount -= scrap.dropChanceDecrease;
        }
    }

    public void ObjectKilled()
    {
        foreach (var scrap in scrapObjects)
        {
            CalcDropChance(scrap);
        }
    }

    private void SpawnScrap(GameObject scrap)
    {
        Vector3 offset = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + Random.Range(-2, 2));
        Instantiate(scrap, offset, Quaternion.identity);
    }
}
