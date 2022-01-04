using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class ReserveOnlyClipType : MonoBehaviour, IFireCondition, IWeaponClipType
    {
        [SerializeField]private float _reserveAmmoMax;

        private float _reserveAmount;

        [System.Serializable]
        public class AmmoChangedEvent : UnityEvent { }

        [SerializeField] public AmmoChangedEvent onAmmoChanged;

        void Start()
        {
            _reserveAmount = _reserveAmmoMax;
        }

        public void AddReserve(float amount)
        {
            float difference = _reserveAmmoMax - _reserveAmount;
            if (amount > difference)
            {
                //re
            }
            _reserveAmount += amount;
        }

        public void SetReserveMax(float amount)
        {
            _reserveAmmoMax = amount;
        }

        public bool CheckClip()
        {
            return _reserveAmount <= 0;
        }

        public void Fillclip(float amount)
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
            _reserveAmount -= reduction;
        }
    }
}
