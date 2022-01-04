using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IDamageableType
    {
        void CheckObject(float damage, GameObject hitObject, GameObject attackerObject);
    }
}
