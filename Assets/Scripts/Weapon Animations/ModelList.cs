using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{

    public class ModelList : MonoBehaviour
    {
        public List<GameObject> models;

        private void Awake()
        {
            Weapon[] modelObjects = GetComponents<Weapon>();
            foreach (var model in modelObjects)
            {
                AddModel(model.gameObject);
            }
        }

        public void AddModel(GameObject model) => models.Add(model);


    }
}
