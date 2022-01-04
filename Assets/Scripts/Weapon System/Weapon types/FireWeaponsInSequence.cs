using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class FireWeaponsInSequence : MonoBehaviour, IFireable
    {
        private int _index;

        private Weapon[] _weapons;


        void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>();
        }



        public void Fire()
        {
            _weapons[_index].FireWeapon();
            _index++;
            _index %= _weapons.Length;
        }

        public void SetFirePoint(Transform point)
        {
            
        }
    }
}
