using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class OverrideProjectileDamage : MonoBehaviour, IOverrideProjectileStat
    {
        [SerializeField] private float _newDamage;



        public void OverrideStat(GameObject projectile)
        {
            var weaponDamage = projectile.GetComponentInChildren<WeaponDamage>();
            var weaponEffects = projectile.GetComponent<IWeaponEffect>();
            weaponDamage?.SetWeaponDamge(_newDamage);
            weaponEffects?.SetStats();
            
        }

        public void ResetOverrideStat(GameObject projectile)
        {
            var weaponDamage = projectile.GetComponentInChildren<WeaponDamage>();
            weaponDamage?.ResetDamage();
        }
    }
}
