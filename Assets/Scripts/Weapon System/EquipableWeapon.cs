using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class EquipableWeapon : MonoBehaviour
    {
        private Weapon _weapon;

        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
        }

        public Weapon ReturnWeapon() => _weapon;
    }
}
