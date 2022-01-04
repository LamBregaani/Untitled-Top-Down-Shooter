using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class LaunchObject : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _moving;

        private float _step;

        private void Awake()
        {
            _step = _speed * Time.deltaTime;
        }

        private void Update()
        {
            if (_moving)
            {

                transform.position += transform.forward * _step;


            }
        }

        public void Stop() => _moving = false;

        public void Launch() => _moving = true;

        public void SetDirection() { }


    }
}
