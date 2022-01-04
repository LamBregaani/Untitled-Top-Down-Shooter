using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class MultishotHitscanWeapon : MonoBehaviour, IFireable
    {
        [SerializeField] private float _spreadAngle;

        [SerializeField] private float _pelletCount;

        private float _spreadAngleAdjust;

        private Transform _firePoint;

        private IWeaponEffect[] _weaponEffectScripts;



        [System.Serializable]
        public class FiredEvent : UnityEvent { }

        [SerializeField] public FiredEvent weaponFired;

        public delegate void TargetHit(GameObject hitObject);

        public event TargetHit targetHit;

        void Awake()
        {
            _weaponEffectScripts = GetComponentsInChildren<IWeaponEffect>();
            _spreadAngleAdjust = _spreadAngle * 0.1f;
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

            weaponFired?.Invoke();


            for (int i = 0; i < _pelletCount; i++)
            {

                Vector3 forwardVector = transform.forward; // Bullet Spread
                forwardVector.x += Random.Range(-_spreadAngleAdjust, _spreadAngleAdjust);
                forwardVector.y += Random.Range(-_spreadAngleAdjust, _spreadAngleAdjust);

                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, forwardVector, out hitInfo))
                {

                    targetHit?.Invoke(hitInfo.collider.gameObject);
                }

            }
            Debug.Log("Fired!");




        }

    }
}
