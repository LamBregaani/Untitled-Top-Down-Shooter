using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        private bool _canFire;

        private IFireCondition[] _fireConditions;

        private IFireable _fireable;



        public delegate void FireHandler();

        private event FireHandler weaponFired;


        public delegate void CheckFireHandler(ref bool fire);

        public event CheckFireHandler checkIfWeaponIsFireable;



        private void Awake()
        {
            _fireConditions = GetComponents<IFireCondition>();

            _fireable = GetComponent<IFireable>();
        }

        private void OnEnable()
        {
            foreach (var preventFire in _fireConditions)
            {
                checkIfWeaponIsFireable += preventFire.CheckIfFireable;
            }

            weaponFired += _fireable.Fire;

        }

        private void OnDisable()
        {
            foreach (var preventFire in _fireConditions)
            {
                checkIfWeaponIsFireable -= preventFire.CheckIfFireable;
            }

            weaponFired -= _fireable.Fire;
        }

        public void FireWeapon()
        {

            _canFire = true;
            checkIfWeaponIsFireable?.Invoke(ref _canFire);
            if (_canFire)
            {
                weaponFired?.Invoke();
            }


        }
    }
}
