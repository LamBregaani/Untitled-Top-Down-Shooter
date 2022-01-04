using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem.Animations
{
    public class FloatingSwordAnimations : MonoBehaviour, IWeaponAnimation
    {

        [SerializeField] private float _speed;

        [SerializeField] private Transform _firepoint;

        [SerializeField] private Transform _launchPoint;

        [SerializeField] private GameObject _center;

        [SerializeField]private Transform _startPos;

        private int switchState;

        private float _step;

        private bool launched;

        private bool returning;

        private Transform _nextPos;

        private Collider _col;

        [System.Serializable]
        public class LaunchedEvent : UnityEvent<GameObject> { }

        [SerializeField] public LaunchedEvent launchedEvent;

        [System.Serializable]
        public class PointReachedEvent : UnityEvent<Transform> { }

        [SerializeField] public PointReachedEvent pointReached;



        private void Awake()
        {
            _step = _speed * Time.deltaTime;
            _col = GetComponent<Collider>();
        }

        private void Update()
        {
            switch (switchState)
            {
                case 0:
                    //Idle
                    //transform.RotateAround(_center.transform.position, Vector3.up, _rotateSpeed * Time.deltaTime);
                    
                    break;

                case 2:
                    _nextPos = _launchPoint;
                    launched = true;
                    switchState = 3;
                        break;

                case 3:
                    // moving
                    if (Vector3.Distance(transform.position, _nextPos.position) > 0.01f)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, _nextPos.position, _step);


                    }
                    else
                    {
                        if (returning)
                        {
                            returning = false;
                            switchState = 0;
                        }
                        else if(launched)
                        {
                            switchState = 5;
                        }
                        else
                        {
                            switchState = 4;
                        }


                    }
                    break;

                case 4:
                    //Return

                    _col.enabled = false;
                    pointReached.Invoke(_startPos);
                    
                    break;

                case 5:
                    //Launch
                    this.transform.rotation = _launchPoint.transform.rotation;
                    launchedEvent.Invoke(this.gameObject);
                    transform.parent = null;
                    launched = false;
                    switchState = 0;
                    break;
                case 6:

                    this.transform.parent = _startPos.transform;
                    switchState = 0;
                    break;

            }


        }




        public void StartAnimation(int index)
        {
            this.transform.parent = null;
            _col.enabled = true;
            _nextPos = _firepoint;
            switchState = index;
        }
    }
}
