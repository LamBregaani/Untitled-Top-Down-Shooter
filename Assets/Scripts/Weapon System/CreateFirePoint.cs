using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class CreateFirePoint : MonoBehaviour
    {
        private Transform _firePoint;

        private GameObject _firePointObj;

        private IFireable _fireable;

        void Awake()
        {
            Vector3 point = new Vector3(transform.position.x, transform.position.y, transform.position.z + (transform.lossyScale.z / 2) + 0.1f);

            _firePointObj = Instantiate(new GameObject(), point, Quaternion.identity);
            _firePointObj.transform.parent = gameObject.transform;
            _firePoint = _firePointObj.transform;
            _fireable = GetComponentInChildren<IFireable>();
            _fireable.SetFirePoint(_firePoint);

        }
    }
}

