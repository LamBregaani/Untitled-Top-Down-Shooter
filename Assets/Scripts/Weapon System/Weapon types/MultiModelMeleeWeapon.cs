using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class MultiModelMeleeWeapon : MonoBehaviour, IFireable
    {

        private Transform _firePoint;

        private IWeaponEffect[] _weaponEffectScripts;



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;



        private void Awake()
        {
            _weaponEffectScripts = GetComponentsInChildren<IWeaponEffect>();
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









            Debug.Log("Fired!");



        }
    }
}
