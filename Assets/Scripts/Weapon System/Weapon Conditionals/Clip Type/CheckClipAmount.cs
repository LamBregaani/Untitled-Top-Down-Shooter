using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace WeaponSystem
{
    public class CheckClipAmount : MonoBehaviour, IFireCondition, IWeaponClipType
    {
        public float clipAmount; //{ get; set; }

        public float maxClipSize; //{ get; private set; }

        [SerializeField] private float _reserveAmmo;

        private float _reserveAmmoMax;

        public bool CheckClip()
        {
            return clipAmount <= 0;
        }

        public void Fillclip(float amount)
        {
            float differance = maxClipSize - clipAmount;
            if (_reserveAmmo >= maxClipSize)
            {
                clipAmount = maxClipSize;
                _reserveAmmo -= differance;
            }
            else if (_reserveAmmo < maxClipSize && _reserveAmmo > differance)
            {
                clipAmount += differance;
                _reserveAmmo -= differance;
            }
            else
            {
                clipAmount += _reserveAmmo;
                _reserveAmmo = 0;
            }


        }

        private void ReduceReserve(float amount)
        {

        }

        public void SetReserveMax(float amount)
        {

        }

        public void CheckIfFireable(ref bool fire)
        {

            if (CheckClip())
            {
                fire = false;

            }

        }

        public void ReduceClip(float reduction)
        {
            clipAmount -= reduction;
        }

        public void AddReserve(float amount)
        {
            if (_reserveAmmo < _reserveAmmoMax)
                _reserveAmmo += amount;
        }


    }
}
