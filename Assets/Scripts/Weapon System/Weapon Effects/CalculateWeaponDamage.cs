using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class CalculateWeaponDamage : MonoBehaviour, IWeaponEffect
    {
        //The intial damage of the weapon
        private float _startDamage;

        //The damge sent after calculating
        private float _actualDamage;

        //Damage modifier
        private float _modifier = 1;

        //Gets the weapon damage
        private WeaponDamage _weaponDamage;

        //Gets the scipts that dictate what this weapon can damage
        private IDamageableType[] _Damageables;


        public delegate void TargetHit(float damage, GameObject hitObject, GameObject attackerObject);

        public event TargetHit targetHit;



        private void Awake()
        {
            _Damageables = GetComponentsInChildren<IDamageableType>();
            _weaponDamage = GetComponent<WeaponDamage>();
            
        }

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            SetStats();
            foreach (var damagable in _Damageables)
            {
                targetHit += damagable.CheckObject;
            }
        }

        private void OnDisable()
        {
            foreach (var damagable in _Damageables)
            {
                targetHit -= damagable.CheckObject;
            }
        }


        void DamageModifier(float modifierAdd)
        {
            _modifier += modifierAdd;

        }

        public void WeaponEffect(GameObject hitObject)
        {
            _actualDamage = _startDamage * _modifier;
            targetHit?.Invoke(_actualDamage, hitObject, this.gameObject);
        }

        public void SetStats()
        {
            _startDamage = _weaponDamage.ReturnWeaponDamage();
        }
    }
}
