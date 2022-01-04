using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class ProjWeaponFromPool : MonoBehaviour, IFireable
    {
        [SerializeField] private Weapon[] _projectiles;

        private int _index;

        private Transform _firePoint;

        private GameObject _firePointObj;

        private IOverrideProjectileStat[] _overrides;



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void ProjectileOverride(GameObject proj);

        public event ProjectileOverride projOverride;



        void Awake()
        {
            _overrides = GetComponents<IOverrideProjectileStat>();

        }

        private void OnEnable()
        {
            AddMethods();
            //projOverride?.Invoke(_projectile);
        }

        private void OnDisable()
        {
            RemoveMethods();
        }

        void AddMethods()
        {
            foreach (var overrideScript in _overrides)
            {
                projOverride += overrideScript.OverrideStat;
            }
        }

        void RemoveMethods()
        {
            foreach (var overrideScript in _overrides)
            {
                projOverride -= overrideScript.OverrideStat;
            }
        }


        public void SetFirePoint(Transform point)
        {
            _firePoint = point;
        }

        public void Fire()
        {

            weaponFired.Invoke();
            //_projectiles[index];
            _index++;
            _index %= _projectiles.Length;
            Debug.Log("Fired!");

        }
    }
}
