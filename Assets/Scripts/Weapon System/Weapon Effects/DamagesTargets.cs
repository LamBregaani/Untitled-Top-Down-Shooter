using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class DamagesTargets : MonoBehaviour, IDamageableType
    {
        private StoreTarget _targetList;

        void Awake()
        {
            _targetList = GetComponentInParent<StoreTarget>();
        }

        public void CheckObject(float damage, GameObject hitObject, GameObject attackerObject)
        {
            foreach (var target in _targetList.targets)
            {

            }
        }
    }
}
