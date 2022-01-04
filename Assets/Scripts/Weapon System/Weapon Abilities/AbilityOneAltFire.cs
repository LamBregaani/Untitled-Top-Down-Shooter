using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class AbilityOneAltFire : MonoBehaviour, IAbilityOne<bool>
    {
        private Weapon _altWeapon;


        private void Awake()
        {
            _altWeapon = GetComponent<Weapon>();
        }

        public void UseAbility(bool activated)
        {
            if (activated)
            {
                _altWeapon.FireWeapon();
            }

        }
    }
}