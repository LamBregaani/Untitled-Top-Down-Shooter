using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    
    public class SetObjectPositionsAroundPoint : MonoBehaviour
    {


        [SerializeField] private float _rotateSpeed;

        private bool _canRotate = true;

        private ModelList _modelList;

        private void Awake()
        {
            _modelList = GetComponent<ModelList>();


        }

        private void Start()
        {
            var models = _modelList.models;
            float rotation = 360 / models.Count;
            foreach (var model in models)
            {

                model.transform.position = transform.position + new Vector3(1f, 0f, 0f);
                transform.Rotate(0f, rotation, 0f);
            }
            transform.Rotate(0f, 0f, 0f);
        }


    }
}
