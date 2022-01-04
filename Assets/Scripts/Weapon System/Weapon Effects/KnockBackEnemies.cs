using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class KnockBackEnemies : MonoBehaviour, IWeaponEffect
    {
        [SerializeField] private float knockbackForce;

        public void SetStats()
        {
            throw new System.NotImplementedException();
        }

        public void WeaponEffect(GameObject hitObject)
        {
            //var enemy = hitObject.GetComponent<EnemyHealth>();
            //if (enemy != null)
            //{
            //    Vector3 direction = hitObject.transform.position - transform.position;
            //    direction.y = 0;
            //    Rigidbody rb = enemy.GetComponent<Rigidbody>();
            //    if(rb != null)
            //    {
            //        rb.isKinematic = false;
            //        rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
            //        StartCoroutine(KnockBackTime(rb));
                    
                    
            //    }


            //}
            


        }

        public IEnumerator KnockBackTime(Rigidbody rigid)
        {
            yield return new WaitForSeconds(2);
            rigid.isKinematic = true;
        }
    }
}
