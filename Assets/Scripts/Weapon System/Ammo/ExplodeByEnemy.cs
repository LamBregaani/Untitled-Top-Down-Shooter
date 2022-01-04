using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class ExplodeByEnemy : MonoBehaviour
    {
        private Weapon _weapon;



        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var enemy = other.gameObject.GetComponent<IdamageableByPlayer<float>>();
            if (enemy != null)
            {

                _weapon.FireWeapon();
                enemy = null;

            }

        }

    }
}
