using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class UpdateAmmo : MonoBehaviour
    {
        [SerializeField] private int _ammoCost;

        private IWeaponClipType _clipType;

        private void Awake()
        {
            _clipType = GetComponent<IWeaponClipType>();
        }


        public void ReduceAmmo()
        {
            _clipType.ReduceClip(_ammoCost);
            
        }

        public void WeaponEffect()
        {
            
        }

        public void SetStats()
        {
            throw new System.NotImplementedException();
        }
    }
}
