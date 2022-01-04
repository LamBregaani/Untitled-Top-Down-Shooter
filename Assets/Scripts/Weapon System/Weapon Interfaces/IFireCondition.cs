using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IFireCondition
    {
        void CheckIfFireable(ref bool fire);
    }
}
