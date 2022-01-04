using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WeaponSystem
{
    public class SwitchWeapons : MonoBehaviour
    {

        private List<Weapon> weapons = new List<Weapon>();

        private Weapon equipedWeapon;

        private int weaponIndex;

        private int val;

        [System.Serializable]
        public class WeaponChangedEvent : UnityEvent<Weapon> { }

        [SerializeField] public WeaponChangedEvent weaponChanged;


        private void Awake()
        {


            foreach (var weapon in GetComponentsInChildren<EquipableWeapon>())
            {
                AddWeapon(weapon.ReturnWeapon());
            }


        }



        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            foreach (Weapon weapon in weapons)
            {
                weapon?.gameObject.SetActive(false);
            }
            equipedWeapon = weapons[weaponIndex];
            equipedWeapon.gameObject.SetActive(true);
            weaponChanged.Invoke(weapons[weaponIndex]);
        }

        public void SwitchWeapon(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                weaponIndex += val;

                weaponIndex %= weapons.Count;
                if (weaponIndex < 0)
                {
                    weaponIndex = weapons.Count - 1;
                }
                equipedWeapon.gameObject.SetActive(false);

                equipedWeapon = weapons[weaponIndex];
                equipedWeapon.gameObject.SetActive(true);
                weaponChanged.Invoke(weapons[weaponIndex]);
            }

        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void Value(int value)
        {
            val = value;
        }



    }
}
