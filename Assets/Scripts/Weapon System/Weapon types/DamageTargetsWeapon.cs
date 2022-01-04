using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class DamageTargetsWeapon : MonoBehaviour, IFireable
    {
        private Transform _firePoint;

        private StoreTarget _storeTargets;

        private IWeaponEffect[] _weaponEffectScripts;



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;



        private void Awake()
        {
            _weaponEffectScripts = GetComponentsInChildren<IWeaponEffect>();
            _storeTargets = GetComponentInParent<StoreTarget>();

        }

        private void OnEnable()
        {
            foreach (var item in _weaponEffectScripts)
            {
                targetHit += item.WeaponEffect;
            }


        }

        private void OnDisable()
        {
            foreach (var item in _weaponEffectScripts)
            {
                targetHit -= item.WeaponEffect;
            }
        }

        public void SetFirePoint(Transform point)
        {
            _firePoint = point;
        }

        public void Fire()
        {

            weaponFired.Invoke();
            foreach (var obj in _storeTargets.targets)
            {
                ITarget target = obj.GetComponent<ITarget>();
                target?.SetTarget(this.gameObject);
                targetHit?.Invoke(obj.gameObject);
            }
            Debug.Log("Fired!");



        }
    }
}
