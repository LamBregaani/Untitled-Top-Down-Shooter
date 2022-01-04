using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class DestroyWeapon : MonoBehaviour
    {
        public void SetStats()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
