using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WeaponSystem
{
    public class PlayerUseAbilityOne : MonoBehaviour
    {
        private IAbilityOne<bool> _currentAbilityOne;

        private bool _activated;

        private void Awake()
        {
            _currentAbilityOne = GetComponentInChildren<IAbilityOne<bool>>();
            if (_currentAbilityOne == null)
                print("No Ability two equiped!");
        }




        public void UseAbility(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _activated = true;
                _currentAbilityOne.UseAbility(_activated);

            }
            else if (context.canceled)
            {
                _activated = false;
                _currentAbilityOne.UseAbility(_activated);
            }

        }

        public void UpdateAbility(Weapon weapon)
        {
            _currentAbilityOne = GetComponentInChildren<IAbilityOne<bool>>();
            if (_currentAbilityOne == null)
                print("No Ability two equiped!");
        }
    }
}
