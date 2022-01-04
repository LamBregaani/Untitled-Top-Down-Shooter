using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class AddForcecontinuous : MonoBehaviour
    {
        private Rigidbody rd;

        [SerializeField] private float force;


        private void Awake()
        {
            rd = GetComponent<Rigidbody>();
        }


        // Start is called before the first frame update
        void Start()
        {
            rd.AddForce(transform.up * force);
        }

    }
}
