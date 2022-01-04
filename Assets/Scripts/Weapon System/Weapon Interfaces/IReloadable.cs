using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IReloadable
    {
        float ReloadTime();

        float ReloadAmount();
    }
}
