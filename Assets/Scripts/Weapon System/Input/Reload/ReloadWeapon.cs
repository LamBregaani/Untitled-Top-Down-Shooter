using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class ReloadWeapon : MonoBehaviour
    {
        public static event Action<float> ReloadingWeapon = delegate { };

        private IReloadable _currentReloadable;

        private IWeaponClipType _currentClipType;

        private bool reloading;

        private bool reloadable;



        public void Reload()
        {
            if (!reloading && reloadable)
            {
                ReloadingWeapon(_currentReloadable.ReloadTime());
                reloading = true;
                StartCoroutine(ReloadCo());
            }

        }

        IEnumerator ReloadCo()
        {
            while (reloading)
            {
                Debug.Log("Reloading");
                yield return new WaitForSeconds(_currentReloadable.ReloadTime());
                reloading = false;
                Debug.Log("Reloaded!");
                _currentClipType.Fillclip(_currentReloadable.ReloadAmount());

            }


        }

        public void ChangeWeapon(Weapon weapon)
        {
            reloadable = false;
            _currentReloadable = null;
            _currentReloadable = weapon.gameObject.GetComponent<IReloadable>();
            if (_currentReloadable != null)
            {
                _currentClipType = weapon.gameObject.GetComponent<IWeaponClipType>();
                reloadable = true;

            }

        }
    }
}

