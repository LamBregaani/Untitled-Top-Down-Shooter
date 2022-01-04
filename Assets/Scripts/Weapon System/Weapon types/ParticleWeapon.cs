using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class ParticleWeapon : MonoBehaviour, IFireable
    {

        private Transform _firePoint;

        private GameObject _firePointObj;

        private ParticleSystem[] _particles;

        private Collider _collider;

        private IWeaponEffect _weaponEffectScript;



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;





        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
            _particles = GetComponentsInChildren<ParticleSystem>();
            foreach (var part in _particles)
            {
                part.transform.parent = null;
            }
            _weaponEffectScript = GetComponentInChildren<IWeaponEffect>();
        }

        private void OnEnable()
        {

            targetHit += _weaponEffectScript.WeaponEffect;

        }

        private void OnDisable()
        {
            targetHit -= _weaponEffectScript.WeaponEffect;
        }

        public void SetFirePoint(Transform point)
        {
            _firePoint = point;
        }

        public void Fire()
        {
            _collider.enabled = true;
            foreach (var part in _particles)
            {
                part.Play();
            }
            weaponFired?.Invoke();
            _collider.enabled = false;
        }



        private void OnTriggerEnter(Collider other)
        {
            targetHit?.Invoke(other.gameObject);
        }
    }
}
