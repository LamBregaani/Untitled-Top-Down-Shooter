using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IOverrideProjectileStat
    {
        void OverrideStat(GameObject projectile);

        void ResetOverrideStat(GameObject projectile);
    }
}
