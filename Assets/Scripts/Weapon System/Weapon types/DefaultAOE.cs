using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class DefaultAOE : MonoBehaviour, IFireable
    {
        
        [SerializeField] private float _attackRadius;

        private Collider[] _hitColliders;

        private IWeaponEffect[] _weaponEffectScripts;

        [Tooltip("Decides what layers this weapon will check")]
        [SerializeField] private LayerMask mask;

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
            foreach (var weaponEffect in _weaponEffectScripts)
            {
                targetHit += weaponEffect.WeaponEffect;
            }


        }

        private void OnDisable()
        {
            foreach (var weaponEffect in _weaponEffectScripts)
            {
                targetHit -= weaponEffect.WeaponEffect;
            }
        }

        public void SetFirePoint(Transform point)
        {

        }

        public void Fire()
        {
            

            _hitColliders = Physics.OverlapSphere(transform.position, _attackRadius, mask);

            Debug.Log("fired");
            foreach (var objects in _hitColliders)
            {
                targetHit?.Invoke(objects.gameObject);
            }
            weaponFired.Invoke();
        }



    }
}
