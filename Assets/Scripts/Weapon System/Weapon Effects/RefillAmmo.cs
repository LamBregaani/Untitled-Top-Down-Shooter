using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class RefillAmmo : MonoBehaviour, IWeaponEffect
    {
        [SerializeField] private float _refillAmount;

        private IWeaponClipType _clipType;

        public void SetStats()
        {
            throw new System.NotImplementedException();
        }

        public void WeaponEffect(GameObject hitObject)
        {
            _clipType = hitObject.GetComponent<IWeaponClipType>();
            if (_clipType != null)
            {
                _clipType.AddReserve(_refillAmount);
            }
        }
    }
}
