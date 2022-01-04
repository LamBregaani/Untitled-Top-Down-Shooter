using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class DefaultProjectileWeapon : MonoBehaviour, IFireable
    {
        [SerializeField] private GameObject _projectile;

        private Transform _firePoint;

        private GameObject _firePointObj;

        private IOverrideProjectileStat[] _overrides;

        



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void ProjectileOverride(GameObject proj);

        public event ProjectileOverride projOverride;

        public delegate void ProjectileReset(GameObject proj);

        public event ProjectileOverride projReset;




        void Awake()
        {
            _overrides = GetComponents<IOverrideProjectileStat>();
            AddMethods();
            projOverride?.Invoke(_projectile);
        }

        private void OnEnable()
        {
            AddMethods();
            projOverride?.Invoke(_projectile);
        }

        private void OnDisable()
        {

            projReset?.Invoke(_projectile);
            RemoveMethods();
        }

        void AddMethods()
        {
            foreach (var overrideScript in _overrides)
            {
                projOverride += overrideScript.OverrideStat;
                projReset += overrideScript.ResetOverrideStat;
            }
        }

        void RemoveMethods()
        {
            foreach (var overrideScript in _overrides)
            {
                projOverride -= overrideScript.OverrideStat;
                projReset -= overrideScript.ResetOverrideStat;
            }
        }


        public void SetFirePoint(Transform point)
        {
            _firePoint = point;
        }

        public void Fire()
        {

            weaponFired.Invoke();

            var proj = Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
            

        }
    }
}
