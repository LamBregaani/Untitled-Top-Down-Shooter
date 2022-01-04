using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class ExplodeByTime : MonoBehaviour
    {
        private Weapon _weapon;

        [SerializeField] private float lifeTime;

        private void Awake()
        {
            _weapon = GetComponentInParent<Weapon>();
        }

        private void Start()
        {
            StartCoroutine(LifeTimeCo());
        }

        private IEnumerator LifeTimeCo()
        {
            yield return new WaitForSeconds(lifeTime);
            _weapon.FireWeapon();


        }
    }
}
