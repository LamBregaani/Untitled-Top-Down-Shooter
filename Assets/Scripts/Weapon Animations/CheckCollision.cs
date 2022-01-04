using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class CheckCollision : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        private bool checkCollision;

        private Coroutine lifeTimeCo;

        [System.Serializable]
        public class ObjectHitEvent : UnityEvent { }

        [SerializeField] public ObjectHitEvent objectHit;

        public void Checked()
        {
            checkCollision = true;
            if (lifeTimeCo != null)
                StopCoroutine(lifeTimeCo);
            lifeTimeCo = StartCoroutine(LifeTime());
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (checkCollision)
            {
                Collided();
            }
        }

        private void Collided()
        {
            checkCollision = false;
            objectHit.Invoke();
            StopCoroutine(lifeTimeCo);
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Collided();

        }
    }
}
