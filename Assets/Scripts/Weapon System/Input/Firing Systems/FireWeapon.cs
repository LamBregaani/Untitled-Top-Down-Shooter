using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WeaponSystem
{
    public class FireWeapon : MonoBehaviour
    {
        private bool _firing;

        private Weapon _currentWeapon;



        private void Awake()
        {
            //_currentWeapon = GetComponentInChildren<Weapon>();

        }

        void Update()
        {
            if (_firing)
            {
                Firing();
            }
        }

        public void Firing(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _firing = true;

            }
            else if (context.canceled)
            {
                _firing = false;
            }
        }

        public void UpdateWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;
            if (_currentWeapon == null)
                print("No weapon equiped!");
        }

        public void Firing()
        {
            _currentWeapon.FireWeapon();
        }
    }
}
