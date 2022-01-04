using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class SetAmmoReserveToModelList : MonoBehaviour
    {
        private ModelList _modelList;

        private IWeaponClipType _clipType;

        private void Awake()
        {
            _modelList = GetComponentInChildren<ModelList>();

            _clipType = GetComponent<IWeaponClipType>();

            _clipType.SetReserveMax(_modelList.models.Count);
        }


    }
}
