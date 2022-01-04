using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class DamagesPlayer : MonoBehaviour, IDamageableType
    {
        public void CheckObject(float damage, GameObject hitObject, GameObject attackerObject)
        {
            IdamageableByEnemy<float> damageable = hitObject.GetComponent<IdamageableByEnemy<float>>();

            if (damageable != null)
            {

                damageable.TakeDamage(damage);


            }
        }
    }
}
