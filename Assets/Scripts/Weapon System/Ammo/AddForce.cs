using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class AddForce : MonoBehaviour
    {
        [SerializeField] private float _force;

        private Rigidbody _rd;



        private void Awake()
        {
            _rd = GetComponentInChildren<Rigidbody>();
        }


        // Start is called before the first frame update
        void Start()
        {
            _rd.AddForce(transform.forward * _force + (transform.up * 100));
        }

    }
}
