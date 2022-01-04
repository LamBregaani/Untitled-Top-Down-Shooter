using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{


    public GameObject playerTarget;
    public Transform coreTarget;
    public RoundController roundController;

    private bool inCoreRange;

    public int enemySpeed;

    private NavMeshAgent agent;

    //Scrap
    public GameObject scrapObject;
    private Vector3 offSet;

    

    public float bulletSpeed;

    public float fireRate;
    private float shotDelayCounter;

    public Transform firePoint;

    // Start is called before the first frame update

    


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();


        agent.speed = 3;
        //coreTarget = GameObject.FindWithTag("Core").transform;
        playerTarget = GameObject.FindWithTag("Player");
        MoveToCore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToCore()
    {
        agent.destination = coreTarget.position;
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CoreRange")
        {
            transform.LookAt(coreTarget);
            agent.isStopped= true;

        }
    }

    public void HitByBullet()
    {
        offSet.y = 1;
        //offSet.x = Random.Range(0, 3);
       // offSet.z = Random.Range(0, 3);
        GameObject scrap = Instantiate(scrapObject, transform.position + offSet, Quaternion.identity);
        Scrap scrapScript = scrap.GetComponent<Scrap>();
        //scrapScript.player = playerTarget;

        Destroy(gameObject);
        roundController.EnemyIsAlive();

    }
}


