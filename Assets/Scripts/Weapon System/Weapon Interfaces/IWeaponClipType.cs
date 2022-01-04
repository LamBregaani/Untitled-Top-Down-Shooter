using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IWeaponClipType
    {
        void Fillclip(float amount);

        void ReduceClip(float reduction);

        void AddReserve(float amount);

        bool CheckClip();

        void SetReserveMax(float amount);
    }
}
