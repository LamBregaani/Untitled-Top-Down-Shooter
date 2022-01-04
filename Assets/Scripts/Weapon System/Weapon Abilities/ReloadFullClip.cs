using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class ReloadFullClip : MonoBehaviour, IReloadable
    {
        [SerializeField] private float _reloadTime;

        public float ReloadTime()
        {
            return _reloadTime;
        }

        public float ReloadAmount()
        {
            return 9999;
        }
    }
}
