using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class WeaponDamage : MonoBehaviour
    {
        [SerializeField] private float _startDamage;

        [SerializeField]private float _weaponDamage;

        public float ReturnWeaponDamage()
        {
            return _weaponDamage;
        }

        public void SetWeaponDamge(float newDamage)
        {
            _weaponDamage = newDamage;
        }

        public void MultiplyWeaponDamage(float multi)
        {
            _weaponDamage *= multi;
        }

        public void ResetDamage()
        {
            _weaponDamage = _startDamage;
        }
    }
}
