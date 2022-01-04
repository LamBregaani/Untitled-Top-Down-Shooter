using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeaponEffect
    {
        void WeaponEffect(GameObject hitObject);

        void SetStats();
    }
}

