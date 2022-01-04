using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem.Animations
{
    public class ReturnObjectAnimation : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private Transform _startPos;

        private bool _moving;

        private float _step;

        private ModelList _modelList;

        [System.Serializable]
        public class PointReachedEvent : UnityEvent { }

        [SerializeField] public PointReachedEvent returned;


        private void Awake()
        {
            _modelList = GetComponentInParent<ModelList>();
            _step = _speed * Time.deltaTime;
        }

        private void Update()
        {
            if (_moving)
            {
                if (Vector3.Distance(transform.position, _startPos.transform.position) > 0.05f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _startPos.transform.position, _step);


                }
                else
                {
                    _moving = false;
                    returned.Invoke();
                    _modelList.models.Add(this.gameObject);
                }
            }
        }


        public void ReturnToStart() => _moving = true;
    }
}
