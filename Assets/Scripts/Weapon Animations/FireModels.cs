using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem.Animations;

namespace WeaponSystem
{
    public class FireModels : MonoBehaviour
    {
        private int _index;

        private ModelList _modelList;

        private IWeaponAnimation modelToFire;



        private void Awake()
        {
            _modelList = GetComponentInChildren<ModelList>();
        }

        public void Fire(int state)
        {
            if (_modelList.models.Count != 0)
            {
                _modelList.models[0].GetComponentInChildren<IWeaponAnimation>().StartAnimation(state);
                _modelList.models.Remove(_modelList.models[0]);
            }
        }
    }
}
