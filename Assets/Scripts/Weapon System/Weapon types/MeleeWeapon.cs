using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class MeleeWeapon : MonoBehaviour, IFireable
    {
        private GameObject _target;

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

        private void OnTriggerEnter(Collider other)
        {
            _target = other.gameObject;
            Fire();
        }

        public void Fire()
        {
            targetHit?.Invoke(_target);
        }

        public void SetFirePoint(Transform point)
        {

        }
    }
}
