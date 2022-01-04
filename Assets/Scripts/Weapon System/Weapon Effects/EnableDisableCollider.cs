using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class EnableDisableCollider : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        [SerializeField]private Collider[] colliders;

        private Coroutine lifeTimeCo;



        private void Awake()
        {
            if(colliders.Length == 0)
            {
                colliders = GetComponentsInChildren<Collider>();
            }
        }

        public void EnableColliders()
        {
            foreach (var col in colliders)
            {
                col.enabled = true;
            }
            if (lifeTimeCo != null)
                StopCoroutine(lifeTimeCo);
            lifeTimeCo = StartCoroutine(LifeTime());
        }

        public void DisableColliders()
        {
            foreach (var col in colliders)
            {
                col.enabled = false;
            }
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            DisableColliders();
        }
    }
}
