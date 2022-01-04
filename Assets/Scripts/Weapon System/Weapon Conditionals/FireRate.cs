using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class FireRate : MonoBehaviour, IFireCondition
    {

        [SerializeField] private float _fireRate;

        public float FireRateReturn 
        {
            get => _fireRate;

        }

        private float _nextFireTime;

        private bool CanFire() => Time.time >= _nextFireTime;


        public void CheckIfFireable(ref bool fire)
        {


            if (CanFire())
            {
                _nextFireTime = Time.time + _fireRate;
            }
            else
            {
                fire = false;
            }

        }
    }
}
