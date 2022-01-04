using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WeaponSystem
{
    public class RevUpWeapon : MonoBehaviour, IAbilityOne<bool>
    {
        [SerializeField] private float _speedPenalty;

        [SerializeField] private float _revUpTime;

        [SerializeField] public SpeedPenaltyEvent penalty;

        private Coroutine revUp;



        [System.Serializable]
        public class RevEvent : UnityEvent<bool> { }

        [SerializeField] public RevEvent RevComplete;


        [System.Serializable]
        public class SpeedPenaltyEvent : UnityEvent<float> { }





        public void UseAbility(bool activated)
        {
            if (activated)
            {
                penalty.Invoke(-_speedPenalty);
                if (revUp != null)
                    StopCoroutine(revUp);
                revUp = StartCoroutine(RevUpCo());
            }
            else
            {
                StopCoroutine(RevUpCo());
                RevComplete.Invoke(false);
                penalty.Invoke(_speedPenalty);
            }

        }

        private IEnumerator RevUpCo()
        {
            yield return new WaitForSeconds(_revUpTime);
            RevComplete.Invoke(true);

            print("Revved");
        }
    }
}
