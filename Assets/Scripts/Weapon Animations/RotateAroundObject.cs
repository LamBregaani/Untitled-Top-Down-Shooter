using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem.Animations
{
    public class RotateAroundObject : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;

        [SerializeField] private Transform _center;




        private void Update()
        {
            transform.RotateAround(_center.transform.position, Vector3.up, _rotateSpeed * Time.deltaTime);
        }
    }
}
