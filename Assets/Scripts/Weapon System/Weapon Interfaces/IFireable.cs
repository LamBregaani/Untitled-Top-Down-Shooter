using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IFireable
    {
        void Fire();

        void SetFirePoint(Transform point);
    }
}
