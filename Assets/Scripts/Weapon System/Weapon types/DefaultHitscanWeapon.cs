using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class DefaultHitscanWeapon : MonoBehaviour, IFireable
    {
        private Transform firePoint;

        private IWeaponEffect[] weaponEffectScripts;

        [Tooltip("Decides what layers this weapon will check")]
        [SerializeField] LayerMask mask;

        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;


        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;

        int layer;

        private void Awake()
        {
            weaponEffectScripts = GetComponentsInChildren<IWeaponEffect>();

            layer = 1 >> 7;

            layer = ~layer;
        }

        private void OnEnable()
        {
            foreach (var item in weaponEffectScripts)
            {
                targetHit += item.WeaponEffect;
            }


        }

        private void OnDisable()
        {
            foreach (var item in weaponEffectScripts)
            {
                targetHit -= item.WeaponEffect;
            }
        }

        public void SetFirePoint(Transform point)
        {
            firePoint = point;
        }

        public void Fire()
        {


            weaponFired.Invoke();
            RaycastHit hitInfo;
            if (Physics.Raycast(firePoint.position, transform.forward, out hitInfo, Mathf.Infinity, mask))
            {
                ITarget target = hitInfo.collider.GetComponent<ITarget>();
                if (target != null)
                {
                    target.SetTarget(this.gameObject);
                }

                targetHit?.Invoke(hitInfo.collider.gameObject);


            }


            Debug.Log($"Fired!{gameObject.name}");



        }


    }
}
