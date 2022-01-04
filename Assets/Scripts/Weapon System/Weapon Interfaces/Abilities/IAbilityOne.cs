using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IAbilityOne<T>
    {
        void UseAbility(T activated);

    }
}
