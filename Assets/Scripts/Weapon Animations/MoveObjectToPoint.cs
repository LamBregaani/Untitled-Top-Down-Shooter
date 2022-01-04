using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem.Animations
{
    public class MoveObjectToPoint : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private Transform _firepoint;

        [SerializeField] private GameObject _objectToMove;

        private int switchState;

        private float _step;

        private bool launched;

        private Transform _startPos;

        private Transform _nextPos;

        private Collider col;

        [System.Serializable]
        public class secondEffectEvent : UnityEvent<bool> { }

        [SerializeField] public secondEffectEvent secondEffect;

        [System.Serializable]
        public class PointReachedEvent : UnityEvent<GameObject> { }

        [SerializeField] public PointReachedEvent pointReached;



        private void Awake()
        {
            _step = _speed * Time.deltaTime;
            _startPos = this.transform;
            col = _objectToMove.GetComponent<Collider>();
        }

        private bool moving;

        private void Update()
        {
            switch (switchState)
            {
                case 1:
                    // moving
                    if (Vector3.Distance(_objectToMove.transform.position, _nextPos.position) > 0.05f)
                    {
                        _objectToMove.transform.position = Vector3.MoveTowards(_objectToMove.transform.position, _nextPos.position, _step);


                    }
                    else
                    {
                     if(!launched)
                        {
                            switchState = 2;
                        }
                     else
                        {
                            switchState = 3;
                        }

                    }
                    break;

                case 2:
                    //Return
                    pointReached.Invoke(_objectToMove);

                    break;

                case 3:
                    //Launch
                    secondEffect.Invoke(true);
                    
                    break;
            }
            /*if (moving)
            {
                if (Vector3.Distance(_objectToMove.transform.position, _nextPos.position) > 0.05f)
                {
                    _objectToMove.transform.position = Vector3.MoveTowards(_objectToMove.transform.position, _nextPos.position, _step);


                }
                else
                {
                    moving = false;
                    pointReached.Invoke(_objectToMove);
                }
            }*/

            
        }


        public void StartAnimation()
        {
            col.enabled = true;
            switchState = 1;
            _nextPos = _firepoint;
        }
    }
}
