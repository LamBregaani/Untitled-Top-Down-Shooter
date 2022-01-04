using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class FireWeaponOnEnemyContact : MonoBehaviour
    {

        private GameObject hitObject;

        private StoreTarget targetList;

        private Weapon weapon;



        private void Awake()
        {
            targetList = GetComponent<StoreTarget>();
            weapon = GetComponentInChildren<Weapon>();
        }


        private void OnCollisionEnter(Collision collision)
        {

            var enemy = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                hitObject = collision.gameObject;
                Debug.Log("collided");
                targetList.targets.Add(enemy.gameObject);
                weapon.FireWeapon();

            }






        }
    }
}
