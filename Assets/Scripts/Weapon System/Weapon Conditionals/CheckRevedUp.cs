using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WeaponSystem
{
    public class CheckRevedUp : MonoBehaviour, IFireCondition
    {

        private bool _revedUp;


        public void Reved(bool revved)
        {
            _revedUp = revved;
        }


        public void CheckIfFireable(ref bool fire)
        {


            if (!_revedUp)
            {
                fire = false;
            }

        }
    }
}
