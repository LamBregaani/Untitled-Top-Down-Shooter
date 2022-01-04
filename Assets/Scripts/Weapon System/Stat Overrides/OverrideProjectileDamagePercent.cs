using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class OverrideProjectileDamagePercent : MonoBehaviour
    {
        [SerializeField] private float _damagePercent;


        public void OverrideStat(GameObject projectile)
        {
            var WeaponDamage = projectile.GetComponentInChildren<WeaponDamage>();
            WeaponDamage?.MultiplyWeaponDamage(_damagePercent);
        }
    }
}
