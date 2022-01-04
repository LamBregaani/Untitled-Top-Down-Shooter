using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class CheckIfSpinning : MonoBehaviour, IFireCondition
    {
        private TurretSpin spin;

        void Awake()
        {
            spin = GetComponentInParent<TurretSpin>();
        }

        public void CheckIfFireable(ref bool fire)
        {
            if (spin.rotateSpeed < 200)
            {
                fire = false;
            }
        }
    }
}
