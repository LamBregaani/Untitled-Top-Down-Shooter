using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class DamagesEnemy : MonoBehaviour, IDamageableType
    {
        public void CheckObject(float damage, GameObject hitObject, GameObject attackerObject)
        {
            IdamageableByPlayer<float> damageable = hitObject.GetComponent<IdamageableByPlayer<float>>();

            if (damageable != null)
            {

                damageable.TakeDamage(damage);

            }
        }
    }
}
