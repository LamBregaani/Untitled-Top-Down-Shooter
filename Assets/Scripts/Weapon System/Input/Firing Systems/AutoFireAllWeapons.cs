using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class AutoFireAllWeapons : MonoBehaviour
    {
        [SerializeField] private float fireRateModifier = 1f;

        public bool canFire;

        private float _lowestFirerate;

        private Weapon[] _weapons;

        private FireRate[] _fireRates;



        private void Awake()
        {
            _fireRates = GetComponentsInChildren<FireRate>();
        }

        private void Start()
        {
            UpdateWeapons();
            StartCoroutine(Fire());
        }

        private void Update()
        {
            if (canFire)
            {
                StartCoroutine(Fire());
            }
        }

        public void Firing()
        {
            foreach (var weapon in _weapons)
            {
                weapon.FireWeapon();
            }

        }

        private void UpdateWeapons()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            if (_weapons == null)
                print("No weapons equiped!");
            FindLowestFireRate();
        }


        private void FindLowestFireRate()
        {
            _lowestFirerate = _fireRates[0].FireRateReturn;
            ;
            for (int i = 1; i < _weapons.Length; i++)
            {
                if (_fireRates[i].FireRateReturn < _lowestFirerate)
                {
                    _lowestFirerate = _fireRates[i].FireRateReturn;
                }

            }
        }

        private IEnumerator Fire()
        {
            canFire = false;
            Firing();
            yield return new WaitForSeconds(_lowestFirerate);
            canFire = true;



        }

    }
}
